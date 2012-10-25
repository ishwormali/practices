using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileOutlook.Core.Mail;
using System.Windows.Forms;
using AgileOutlook.Core;
using System.Reflection;
using Microsoft.Office.Interop.Outlook;
using log4net;
using Outlook = Microsoft.Office.Interop.Outlook;

using Office = Microsoft.Office.Core;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel.Composition;

namespace AgileOutlook.Mail
{
    [Export(typeof(IMailHandler))]
    public class MailHandler:IMailHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private SyncItems syncItems = new SyncItems();
        IAgileOutlookAddIn BaseAddIn;
        Timer mailCheckTimer;
        public MailEvent MailReceived{get;set;}
        public MailEvent MailSent { get; set; }
        
        public MailHandler()
        {
            ServiceRegistrar.RegisterService(typeof(IMailHandler), this);
            mailCheckTimer = new Timer();
            mailCheckTimer.Interval = 20000;
            mailCheckTimer.Tick += new EventHandler(mailCheckTimer_Tick);

        }

        public void Startup(IAgileOutlookAddIn baseAddin)
        {
            Log.Debug("mail handler startup.");
            BaseAddIn = baseAddin;

            Plugins.ToList().ForEach(m => m.Startup(baseAddin,this));
            syncItems.ItemSync += SyncItems_ItemSync;

            if (!File.Exists(syncItems.FileName))
            {
                Microsoft.Office.Tools.Outlook.OutlookAddInBase a;

                syncItems.InitializeSyncTimesAccounts(DateTime.Now, this);
                syncItems.Save();
            }
            else
            {
                syncItems.Load();
            }

            BaseAddIn.OutlookApp.NewMailEx += new Outlook.ApplicationEvents_11_NewMailExEventHandler(OutlookApp_NewMailEx);
            //baseAddin.OutlookApp.ItemSend += new Outlook.ApplicationEvents_11_ItemSendEventHandler(OutlookApp_ItemSend);
            HookupSentMail();
            mailCheckTimer.Enabled = true;

            mailCheckTimer.Start();
        }

        void OutlookApp_ItemSend(object Item, ref bool Cancel)
        {
            //SyncMailItem(Item);
            //syncItems.Save();
        }


        void OutlookApp_NewMailEx(string EntryIDCollection)
        {
            Outlook.NameSpace nameSpace = null;
            Outlook.MailItem outlookItem = null;

            try
            {
                nameSpace = BaseAddIn.OutlookApp.GetNamespace("MAPI");

                var entryIds = EntryIDCollection.Split(',');
                foreach (string t in entryIds)
                {
                    outlookItem = nameSpace.GetItemFromID(t) as Outlook.MailItem;

                    if (outlookItem != null)
                    {
                        Log.DebugFormat("Mail received:sender:{0}, received:{1},subject:{2}",outlookItem.SenderName,outlookItem.ReceivedByName,outlookItem.Subject);
                        if (outlookItem is Outlook.MailItem)
                        {
                            var syncItem = SyncMailItem(outlookItem);
                            
                        }

                        Marshal.ReleaseComObject(outlookItem);
                    }
                }

                syncItems.Save();
            }
            finally
            {
                if (nameSpace != null)
                    Marshal.ReleaseComObject(nameSpace);
            }
        }

        private SyncItem SyncMailItem(object outlookItem)
        {
            var outlookMail = (Outlook.MailItem) outlookItem;

            var syncItem = new SyncItem();
            syncItem.EntryID = outlookMail.EntryID;
            syncItem.SenderSubject = outlookMail.Subject;
            syncItem.ReceivedTime = outlookMail.ReceivedTime;
            syncItem.AccountID = MailHelper.GetItemAccountID(outlookItem);
            syncItems.Add(syncItem);
            return syncItem;
        }

        void SyncItems_ItemSync(object sender, SyncItem e)
        {
            // Use this event to handle all incoming e-mails 
            
            var outlookMailItem = MailHelper.GetMailItemFromId(this.BaseAddIn.OutlookApp, e.EntryID);
            
            var eventArg = new MailReceivedEventArgs
            {
                Item=e,
                OutlookApplication=this.BaseAddIn.OutlookApp,
                //OutlookMailItem = outlookMailItem,
                MailItem=new AOMailItem(outlookMailItem)
            };

            if (MailHelper.IsSentItem(outlookMailItem))
            {
                if (MailSent != null)
                {
                    MailSent(this, eventArg);
                }
            }
            else
            {
                if (MailReceived != null)
                {
                    MailReceived(this, eventArg);
                }
            }
            
        }

        private void mailCheckTimer_Tick(object sender, EventArgs e)
        {
            //this.SendMessage(0x04001, IntPtr.Zero, IntPtr.Zero);
            mailCheckTimer.Stop();
            //Log.Debug("mailchecktimer ticked.");
            
            LoopThroughAccountFolders();

            mailCheckTimer.Start();
            //Log.Debug("mailchecktimer ticked complete.");
        }

        DateTime LastReceivedDate;
        private void LoopThroughAccountFolders()
        {
            Outlook.NameSpace nameSpace = BaseAddIn.OutlookApp.GetNamespace("MAPI");
            //var defaultInboxFolder=nameSpace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            var accountFolders = GetWatchFolders();
            //Outlook.Folders accountFolders = nameSpace.Folders;
            for (int i = 0; i < accountFolders.Count; i++)
            {
                Outlook.MAPIFolder accountFolder = accountFolders[i];
                
                //Log.Debug(string.Format("looping through :{0}", accountFolder.FolderPath));

                SyncTime syncTime = syncItems.SyncTimes.Find(
                    s => s.AccountID == accountFolder.EntryID);
                
                if (syncTime != null)
                {
                    LastReceivedDate = DateTime.MinValue;
                    ScanFolder(accountFolder, syncTime.LatestTime, accountFolder.EntryID);
                }

                if (LastReceivedDate > DateTime.MinValue)
                {
                    syncItems.SetSyncTime(LastReceivedDate, accountFolder.EntryID);
                    syncItems.Save();
                }

                if (accountFolder != null)
                    Marshal.ReleaseComObject(accountFolder);
            }

            if (accountFolders != null)
            {
                accountFolders.ToList().ForEach(m => Marshal.ReleaseComObject(m));// Marshal.ReleaseComObject(accountFolders);
            }
                
            if (nameSpace != null)
                Marshal.ReleaseComObject(nameSpace);

        }

        private void ScanFolder(Outlook.MAPIFolder folder, DateTime receivedTime, string accountId)
        {

            if (folder.DefaultItemType == Outlook.OlItemType.olMailItem)
            {
                //Log.Debug(string.Format("scanning folder :{0} and receivedTime:{1}", folder.FolderPath,receivedTime));

                Outlook.Items folderItems = folder.Items;
                Outlook.Items filteredItems = folderItems.Restrict(
                    String.Format("[ReceivedTime] >= '{0}'",
                    receivedTime.AddMinutes(-1).ToString("g")));
                Marshal.ReleaseComObject(folderItems);

                for (int i = 1; i <= filteredItems.Count; i++)
                {
                    object outlookItem = filteredItems[i];

                    //if (!MailHelper.IsSentItem(outlookItem))
                    //{
                        if (outlookItem is Outlook.MailItem)
                        {

                            Outlook.MailItem outlookMail = (Outlook.MailItem)outlookItem;

                            //Log.Debug(string.Format("syncing mail item from :{0} and subject:", outlookMail.SenderName, outlookMail.Subject));

                            var syncItem = SyncMailItem(outlookMail);
                            
                            if (syncItem.ReceivedTime > LastReceivedDate)
                                LastReceivedDate = syncItem.ReceivedTime;
                        }
                    //}

                    Marshal.ReleaseComObject(outlookItem);
                }
            }

            Outlook.Folders subFolders = folder.Folders;
            for (int i = 1; i <= subFolders.Count; i++)
            {
                Outlook.MAPIFolder folderToScan = subFolders[i];
                ScanFolder(folderToScan, receivedTime, accountId);
                Marshal.ReleaseComObject(folderToScan);
            }

            Marshal.ReleaseComObject(subFolders);
        }

        public void ShutDown()
        {
            mailCheckTimer.Enabled = false;
            mailCheckTimer.Stop();
        }

        public IEnumerable<Office.CommandBarControl> OnMailItemContextMenu(Office.CommandBar CommandBar, Office.CommandBarPopup agileCommand, IEnumerable<Outlook.MailItem> selectedMailItems)
        {
            var contextMenus = new List<Office.CommandBarControl>();

            foreach (var plugin in Plugins)
            {
                var tempContextMenus = plugin.OnMailItemContextMenu(CommandBar, agileCommand, selectedMailItems);
                if (tempContextMenus != null)
                {
                    contextMenus.AddRange(tempContextMenus);
                }

            }

            return contextMenus;

        }

        public IList<MAPIFolder> GetWatchFolders()
        {
            var folders = new List<MAPIFolder>();
            Outlook.NameSpace nameSpace = BaseAddIn.OutlookApp.GetNamespace("MAPI");
            var defaultInboxFolder = nameSpace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            
            var sentFolder = nameSpace.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
            folders.Add(defaultInboxFolder);
            folders.Add(sentFolder);

            return folders;
        }

        private void HookupSentMail()
        {
            if (SentItems != null)
            {
                SentItems.ItemAdd -= new ItemsEvents_ItemAddEventHandler(Items_ItemAdd);
            }

            SentItems = GetDefaultNamespace().GetDefaultFolder(OlDefaultFolders.olFolderSentMail).Items;

            SentItems.ItemAdd += new ItemsEvents_ItemAddEventHandler(Items_ItemAdd);
            
        }

        void Items_ItemAdd(object Item)
        {
            var sentMail=Item as MailItem;
            
            Log.DebugFormat("mail sent: sent to:{0} as subject line:{1}", sentMail.ReceivedByName, sentMail.Subject);

            SyncMailItem(Item);
            syncItems.Save();

        }

        private Outlook.NameSpace GetDefaultNamespace()
        {
            return BaseAddIn.OutlookApp.GetNamespace("MAPI");

        }

        ~MailHandler()
        {
            ServiceRegistrar.UnRegisterService(typeof(IAgileOutlookAddIn));
        }

        private Outlook.Items SentItems { get; set; }

        [ImportMany(typeof(IAOMailItemExtension))]
        public IEnumerable<IAOMailItemExtension> Plugins;


        
    }
}

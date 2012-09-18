using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileOutlook.Core.Mail;
using System.Windows.Forms;
using AgileOutlook.Core;
using System.Reflection;
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
        private SyncItems syncItems = new SyncItems();
        IAgileOutlookAddIn BaseAddIn;
        Timer mailCheckTimer;
        public MailReceivedEvent MailReceived{get;set;}

        public MailHandler()
        {
            mailCheckTimer = new Timer();
            mailCheckTimer.Interval = 1000;
            mailCheckTimer.Tick += new EventHandler(mailCheckTimer_Tick);

        }
        public void Startup(IAgileOutlookAddIn baseAddin)
        {
            
            BaseAddIn = baseAddin;

            Plugins.ToList().ForEach(m => m.Startup(baseAddin,this));
            syncItems.NewMailReceived += syncItems_NewMailReceived;

            if (!File.Exists(syncItems.FileName))
            {
                Microsoft.Office.Tools.Outlook.OutlookAddInBase a;

                syncItems.InitializeSyncTimesAccounts(DateTime.Now, BaseAddIn.OutlookApp);
                syncItems.Save();
            }
            else
            {
                syncItems.Load();
            }

            BaseAddIn.OutlookApp.NewMailEx += new Outlook.ApplicationEvents_11_NewMailExEventHandler(OutlookApp_NewMailEx);
            mailCheckTimer.Enabled = true;

            mailCheckTimer.Start();
        }


        void OutlookApp_NewMailEx(string EntryIDCollection)
        {
            Outlook.NameSpace nameSpace = null;
            object outlookItem = null;

            try
            {
                nameSpace = BaseAddIn.OutlookApp.GetNamespace("MAPI");

                string[] entryIds = EntryIDCollection.Split(',');
                for (int i = 0; i < entryIds.Length; i++)
                {
                    outlookItem = nameSpace.GetItemFromID(entryIds[i]);

                    if (outlookItem != null)
                    {
                        if (outlookItem is Outlook.MailItem)
                        {
                            Outlook.MailItem outlookMail = (Outlook.MailItem)outlookItem;
                            
                            SyncItem syncItem = new SyncItem();
                            syncItem.EntryID = outlookMail.EntryID;
                            syncItem.SenderSubject = outlookMail.Subject;
                            syncItem.ReceivedTime = outlookMail.ReceivedTime;
                            syncItem.AccountID = MailHelper.GetItemAccountID(outlookItem);
                            syncItems.Add(syncItem);
                            syncItems.Save();
                        }

                        Marshal.ReleaseComObject(outlookItem);
                    }
                }
            }
            finally
            {
                if (nameSpace != null)
                    Marshal.ReleaseComObject(nameSpace);
            }
        }

        void syncItems_NewMailReceived(object sender, SyncItem e)
        {
            // Use this event to handle all incoming e-mails 

            var eventArg = new MailReceivedEventArgs
            {
                Item=e,
                OutlookApplication=this.BaseAddIn.OutlookApp,
                OutlookMailItem=MailHelper.GetMailItemFromId(this.BaseAddIn.OutlookApp,e.EntryID)
            };


            if (MailReceived != null)
            {
                MailReceived(sender, eventArg);
            }
        }

        private void mailCheckTimer_Tick(object sender, EventArgs e)
        {
            //this.SendMessage(0x04001, IntPtr.Zero, IntPtr.Zero);
            mailCheckTimer.Stop();
            LoopThroughAccountFolders();
        }

        DateTime LastReceivedDate;
        private void LoopThroughAccountFolders()
        {
            Outlook.NameSpace nameSpace = BaseAddIn.OutlookApp.GetNamespace("MAPI");
            Outlook.Folders accountFolders = nameSpace.Folders;
            for (int i = 1; i <= accountFolders.Count; i++)
            {
                Outlook.MAPIFolder accountFolder = accountFolders[i];
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
                Marshal.ReleaseComObject(accountFolders);
            if (nameSpace != null)
                Marshal.ReleaseComObject(nameSpace);

            mailCheckTimer.Start();
        }

        private void ScanFolder(Outlook.MAPIFolder folder, DateTime receivedTime, string accountId)
        {
            if (folder.DefaultItemType == Outlook.OlItemType.olMailItem)
            {
                Outlook.Items folderItems = folder.Items;
                Outlook.Items filteredItems = folderItems.Restrict(
                    String.Format("[ReceivedTime] >= '{0}'",
                    receivedTime.AddMinutes(-1).ToString("g")));
                Marshal.ReleaseComObject(folderItems);

                for (int i = 1; i <= filteredItems.Count; i++)
                {
                    object outlookItem = filteredItems[i];

                    if (!MailHelper.IsSentItem(outlookItem))
                    {
                        if (outlookItem is Outlook.MailItem)
                        {
                            Outlook.MailItem outlookMail = (Outlook.MailItem)outlookItem;

                            SyncItem syncItem = new SyncItem();
                            syncItem.EntryID = outlookMail.EntryID;
                            syncItem.SenderSubject = outlookMail.Subject;
                            syncItem.ReceivedTime = outlookMail.ReceivedTime;
                            syncItem.AccountID = accountId;
                            syncItems.Add(syncItem);

                            if (syncItem.ReceivedTime > LastReceivedDate)
                                LastReceivedDate = syncItem.ReceivedTime;
                        }
                    }

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

        [ImportMany(typeof(IAOMailItemExtension))]
        public IEnumerable<IAOMailItemExtension> Plugins;


        
    }
}

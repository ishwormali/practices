using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using log4net;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
using AgileOutlook.Core;
using System.IO;
using AgileOutlook.Core.Mail;

namespace AgileOutlook
{
    public partial class ThisAddIn:IAgileOutlookAddIn
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure(
                new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AgileOutlook.log.config")));

            //var someValue = System.Configuration.ConfigurationManager.AppSettings["somesetting"];

            Log.Debug("starting up the addin.");
            this.OutlookApp = this.Application;
            
            PluginLocator.ComposeParts(this);
            mailHandler.Startup(this);

            this.Application.ItemContextMenuDisplay += new Outlook.ApplicationEvents_11_ItemContextMenuDisplayEventHandler(Application_ItemContextMenuDisplay);
        }

        void Application_ItemContextMenuDisplay(Office.CommandBar CommandBar, Outlook.Selection Selection)
        {
            if (Selection[1] is Outlook.MailItem)
            {
                OnMailItenContextMenu(CommandBar, Selection);
            }
        }

        void OnMailItenContextMenu(Office.CommandBar CommandBar, Outlook.Selection Selection)
        {
            var mailItems = new List<Outlook.MailItem>();
            foreach (var item in Selection)
            {
                var tempMailItem = item as Outlook.MailItem;
                if (tempMailItem != null)
                {
                    mailItems.Add(tempMailItem);
                }
                
            }

            var cmdMenuItem = (Office.CommandBarPopup)CommandBar.Controls.Add(Office.MsoControlType.msoControlPopup, Type.Missing, Type.Missing, Type.Missing, true);
            cmdMenuItem.Caption = "AgileOutlook";
            mailHandler.OnMailItemContextMenu(CommandBar, cmdMenuItem, mailItems);

            //cmdMenuItem.Click += new Office._CommandBarButtonEvents_ClickEventHandler(tagMenuItem_Click);

        }

        void tagMenuItem_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            //TagWindow window = new TagWindow();
            //Form1 frm = new Form1();
            //frm.Mail = this.Application.ActiveExplorer().Selection[1];
            
            //frm.Show();
            
            //window.ShowDialog();
        }

        

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            mailHandler.ShutDown();
        }

        public Outlook.Application OutlookApp
        {
            get;
            set;
        }


        //[ImportMany(typeof(IMailHandler))]
        //public IEnumerable<IMailHandler> mailHandlers { get; set; }

        [Import(typeof(IMailHandler))]
        public IMailHandler mailHandler { get; set; }

        //public IMailHandler mailHandler
        //{
        //    get { return mailHandlers.FirstOrDefault(); }
        //}

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            

        }

        

        #endregion

    }
}

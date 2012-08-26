using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
using AgileOutlook.Core;
using System.IO;

namespace AgileOutlook
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            ComposeExtensions();
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
            var mailItem=Selection[1] as Outlook.MailItem;
            var cmdMenuItem = (Office.CommandBarPopup)CommandBar.Controls.Add(Office.MsoControlType.msoControlPopup, Type.Missing, Type.Missing, Type.Missing, true);
            cmdMenuItem.Caption = "AgileOutlook";
            foreach (var plugin in Plugins)
            {
                var contextMenu=plugin.GetMailItemContextMenu(mailItem);
                if (contextMenu!=null)
                {
                    if (!contextMenu.IsTopMenu)
                    {
                        cmdMenuItem.Controls.Add(Office.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing,true);
                    }
                }
            }

            //cmdMenuItem.Click += new Office._CommandBarButtonEvents_ClickEventHandler(tagMenuItem_Click);

        }

        void tagMenuItem_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            //TagWindow window = new TagWindow();
            Form1 frm = new Form1();
            frm.Mail = this.Application.ActiveExplorer().Selection[1];

            frm.Show();
            
            //window.ShowDialog();
        }

        public void ComposeExtensions()
        {
            AssemblyCatalog catalog = new AssemblyCatalog(this.GetType().Assembly);
            
            AggregateCatalog catalogs = new AggregateCatalog(catalog);
            var pluginDirectory=Path.Combine( AppDomain.CurrentDomain.BaseDirectory,@"\plugins");
            if(Directory.Exists(pluginDirectory)){
                DirectoryCatalog dirCatalog = new DirectoryCatalog(pluginDirectory);
                catalogs.Catalogs.Add(dirCatalog);
            }
            
            CompositionContainer container = new CompositionContainer(catalogs);
            
            container.ComposeParts(this);
            
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {

        }

        [ImportMany(typeof(IAOExtension))]
        public IEnumerable<IAOExtension> Plugins;

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

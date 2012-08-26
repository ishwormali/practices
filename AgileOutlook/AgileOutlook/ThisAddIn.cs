using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace AgileOutlook
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            
            this.Application.ItemContextMenuDisplay += new Outlook.ApplicationEvents_11_ItemContextMenuDisplayEventHandler(Application_ItemContextMenuDisplay);
        }

        void Application_ItemContextMenuDisplay(Office.CommandBar CommandBar, Outlook.Selection Selection)
        {
            if (Selection[1] is Outlook.MailItem)
            {
                TagContextMenu(CommandBar, Selection);
            }
        }

        void TagContextMenu(Office.CommandBar CommandBar, Outlook.Selection Selection)
        {
            
            var cmdMenuItem = (Office.CommandBarButton)CommandBar.Controls.Add(Office.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);
            cmdMenuItem.Caption = "Tag";
            cmdMenuItem.Click += new Office._CommandBarButtonEvents_ClickEventHandler(tagMenuItem_Click);

        }

        void tagMenuItem_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            //TagWindow window = new TagWindow();
            Form1 frm = new Form1();
            frm.Mail = this.Application.ActiveExplorer().Selection[1];

            frm.Show();
            
            //window.ShowDialog();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {

        }

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

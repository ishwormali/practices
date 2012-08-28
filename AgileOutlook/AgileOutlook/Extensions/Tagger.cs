using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileOutlook.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.ComponentModel.Composition;
using Office = Microsoft.Office.Core;

namespace AgileOutlook.Extensions
{

    [Export(typeof(IAOMailItemExtension))]
    public class Tagger:IAOMailItemExtension
    {

        public void Startup(Microsoft.Office.Tools.Outlook.OutlookAddInBase baseAddin)
        {
            
        }

        public void ShutDown(Microsoft.Office.Tools.Outlook.OutlookAddInBase baseAddin)
        {
            
        }

        public IEnumerable<Office.CommandBarControl> OnMailItemContextMenu(Office.CommandBar CommandBar,Office.CommandBarPopup agileCommand, IEnumerable<Outlook.MailItem> selectedMailItems)
        {
            var taggerMenuItem=(Office.CommandBarButton)agileCommand.Controls.Add(Office.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);

            taggerMenuItem.Caption = "Tag";
            taggerMenuItem.Click += new Office._CommandBarButtonEvents_ClickEventHandler(taggerMenuItem_Click);
            return new List<Office.CommandBarControl>() { taggerMenuItem };
            
        }

        void taggerMenuItem_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            //TagWindow win = new TagWindow();
            TagWindowWpf win = new TagWindowWpf();
            win.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileOutlook.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.ComponentModel.Composition;

namespace AgileOutlook.Extensions
{

    [Export(typeof(IAOExtension))]
    public class Tagger:IAOExtension
    {

        public void Startup(Microsoft.Office.Tools.Outlook.OutlookAddInBase baseAddin)
        {
            
        }

        public void ShutDown(Microsoft.Office.Tools.Outlook.OutlookAddInBase baseAddin)
        {
            
        }

        public AOContextMenuItem GetMailItemContextMenu(Outlook.MailItem mailItem)
        {
            return new AOContextMenuItem() { Caption = "Tag" };
        }
    }
}

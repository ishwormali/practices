using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Outlook;

namespace AgileOutlook.Core
{
    
    public interface IAOExtension
    {
        void Startup(OutlookAddInBase baseAddin);

        void ShutDown(OutlookAddInBase baseAddin);

        AOContextMenuItem GetMailItemContextMenu(Outlook.MailItem mailItem);
    }
}

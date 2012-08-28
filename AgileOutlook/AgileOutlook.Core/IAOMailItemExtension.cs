using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Outlook;
using Office = Microsoft.Office.Core;
namespace AgileOutlook.Core
{
    
    public interface IAOMailItemExtension
    {
        void Startup(OutlookAddInBase baseAddin);

        void ShutDown(OutlookAddInBase baseAddin);

        IEnumerable<Office.CommandBarControl> OnMailItemContextMenu(Office.CommandBar CommandBar, Office.CommandBarPopup agileCommand, IEnumerable<Outlook.MailItem> selectedMailItems);
    }
}

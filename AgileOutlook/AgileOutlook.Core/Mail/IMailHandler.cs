using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace AgileOutlook.Core.Mail
{
    public interface IMailHandler
    {
        MailReceivedEvent MailReceived{get;set;}
        void Startup(IAgileOutlookAddIn baseAddin);
        IEnumerable<Office.CommandBarControl> OnMailItemContextMenu(Office.CommandBar CommandBar, Office.CommandBarPopup agileCommand, IEnumerable<Outlook.MailItem> selectedMailItems);

        void ShutDown();
    }

    public delegate void MailReceivedEvent(object sender, MailReceivedEventArgs e);
}

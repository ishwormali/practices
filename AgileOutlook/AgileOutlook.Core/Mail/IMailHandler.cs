using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace AgileOutlook.Core.Mail
{
    public interface IMailHandler
    {
        MailEvent MailReceived{get;set;}
        MailEvent MailSent { get; set; }

        void Startup(IAgileOutlookAddIn baseAddin);
        IEnumerable<Office.CommandBarControl> OnMailItemContextMenu(Office.CommandBar CommandBar, Office.CommandBarPopup agileCommand, IEnumerable<Outlook.MailItem> selectedMailItems);

        void ShutDown();
        IList<MAPIFolder> GetWatchFolders();
    }

    public delegate void MailEvent(object sender, MailReceivedEventArgs e);

    
}

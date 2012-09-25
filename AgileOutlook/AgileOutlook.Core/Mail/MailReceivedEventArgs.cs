using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

using Office = Microsoft.Office.Core;

namespace AgileOutlook.Core.Mail
{
    public class MailReceivedEventArgs:EventArgs
    {
        public SyncItem Item { get; set; }

        //public Outlook.MailItem OutlookMailItem { get; set; }

        public AOMailItem MailItem { get; set; }

        public Outlook.Application OutlookApplication { get; set; }

        
    }
}

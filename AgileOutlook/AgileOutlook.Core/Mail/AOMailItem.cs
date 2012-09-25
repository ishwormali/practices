using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

using Office = Microsoft.Office.Core;
using System.Runtime.InteropServices;
using AgileOutlook.Core.Mail;

namespace AgileOutlook.Core
{
    public class AOMailItem:IDisposable
    {
        
        public readonly Outlook.MailItem OutlookMailItem;
        bool isDisposed { get;set; }

        public AOMailItem(Outlook.MailItem mailItem)
        {
            OutlookMailItem = mailItem;
            
            
        }

        


        public void Dispose()
        {
            if (isDisposed)
                return;

            Marshal.ReleaseComObject(OutlookMailItem);
            isDisposed = true;
        }


    }
}

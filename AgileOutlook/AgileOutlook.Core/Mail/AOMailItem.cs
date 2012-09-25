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

        public T GetUserPropertyAs<T>(string propName)
        {
            if (OutlookMailItem.UserProperties[propName] == null)
            {
                return default(T);
            }
            
            return (T)OutlookMailItem.UserProperties[propName].Value;
        }

        public void SetUserProperty<T>(string propName,T propValue)
        {
            Outlook.UserProperty prop = OutlookMailItem.UserProperties[propName];
            if (OutlookMailItem.UserProperties[propName] == null)
            {
                prop = OutlookMailItem.UserProperties.Add(propName, MailHelper.GetOutlookPropertyType(propValue));
            }

            prop.Value = propValue;
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

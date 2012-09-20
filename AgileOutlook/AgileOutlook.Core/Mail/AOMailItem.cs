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
        readonly Outlook.MailItem InternalMailItem;
        bool isDisposed { get;set; }

        public AOMailItem(Outlook.MailItem mailItem)
        {
            InternalMailItem = mailItem;
            
        }

        public T GetUserPropertyAs<T>(string propName)
        {
            if (InternalMailItem.UserProperties[propName] == null)
            {
                return default(T);
            }

            return (T)InternalMailItem.UserProperties[propName].Value;
        }

        public void SetUserProperty<T>(string propName,T propValue)
        {
            Outlook.UserProperty prop = InternalMailItem.UserProperties[propName];
            if (InternalMailItem.UserProperties[propName] == null)
            {
                prop = InternalMailItem.UserProperties.Add(propName, MailHelper.GetOutlookPropertyType(propValue));
            }

            prop.Value = propValue;
        }

        public void Dispose()
        {
            if (isDisposed)
                return;

            Marshal.ReleaseComObject(InternalMailItem);
            isDisposed = true;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;

using Office = Microsoft.Office.Core;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections;

namespace AgileOutlook.Core.Mail
{
    public class MailHelper
    {
        public static  bool IsSentItem(object item)
        {
            bool sent = false;
            string receivedByName = string.Empty;

            if (item is Outlook.MailItem)
            {
                Outlook.MailItem receivedMail = (Outlook.MailItem)item;
                sent = receivedMail.Sent;
                receivedByName = receivedMail.ReceivedByName;
            }

            if ((!sent) || (sent && (((receivedByName != null) &&
                ((receivedByName as string) == string.Empty)) || (receivedByName == null))))
            {
                return true;
            }

            return false;
        }

        public  static string GetItemAccountID(object item)
        {
            string accountID = string.Empty;
            object parent = null;
            Outlook.MailItem i;
            
            try
            {
                parent = item.GetType().InvokeMember("Parent",
                    BindingFlags.GetProperty, null, item, new object[] { });
                if (IsNamespace(parent))
                {
                    object entryID = item.GetType().InvokeMember("EntryID",
                        BindingFlags.GetProperty, null, item, new object[] { }); ;
                    if (entryID != null)
                    {
                        accountID = entryID.ToString();
                    }
                }
                else
                {
                    accountID = GetItemAccountID(parent);
                }
            }
            finally
            {
                if (parent != null)
                    Marshal.ReleaseComObject(parent);
            }
            return accountID;
        }

        public static bool IsNamespace(object Folder)
        {
            if (Folder is Outlook.NameSpace)
            {
                return true;
            }
            
            return false;
        }

        public static Outlook.MailItem GetMailItemFromId(Outlook.Application app, string entryId)
        {
            var nameSpace = app.GetNamespace("MAPI") as Outlook.NameSpace;

            var item=nameSpace.GetItemFromID(entryId);
            var mailItem = item as Outlook.MailItem;
            return mailItem;

        }

        public static Outlook.OlUserPropertyType GetOutlookPropertyType(object t)
        {
            if (t == null)
            {
                return Outlook.OlUserPropertyType.olCombination;
            }

            double d;
            int i;
            if (t is bool)
            {
                return Outlook.OlUserPropertyType.olYesNo;
            }
            else if (t is string)
            {
                return Outlook.OlUserPropertyType.olText;
            }
            else if (int.TryParse(t.ToString(),out i) )
            {
                return Outlook.OlUserPropertyType.olInteger;
            }
            else if (double.TryParse(t.ToString(),out d))
            {
                return Outlook.OlUserPropertyType.olNumber;
            }
            else if (t is IEnumerable)
            {
                return Outlook.OlUserPropertyType.olEnumeration;
            }
            else if (t is DateTime)
            {
                return Outlook.OlUserPropertyType.olDateTime;
            }
            else
            {
                return Outlook.OlUserPropertyType.olText;
            }

            
        }

        public static T GetUserPropertyAs<T>(Outlook.MailItem mailItem, string propName)
        {
            if (mailItem.UserProperties[propName] == null)
            {
                return default(T);
            }

            return (T)mailItem.UserProperties[propName].Value;
        }

        public static void SetUserProperty<T>(Outlook.MailItem mailItem, string propName, T propValue)
        {
            Outlook.UserProperty prop = mailItem.UserProperties[propName];
            if (mailItem.UserProperties[propName] == null)
            {
                prop = mailItem.UserProperties.Add(propName, MailHelper.GetOutlookPropertyType(propValue));
            }

            prop.Value = propValue;
        }

        public static Outlook.UserProperty GetOrCreateUserProperty(Outlook.MailItem mailItem, string propName,OlUserPropertyType propertyType)
        {
            var prop=mailItem.UserProperties[propName];
            if (prop!=null)
            {
                return prop;
            }
            else
            {
                prop = mailItem.UserProperties.Add(propName, propertyType);

            }

            return prop;
        }
    }
}

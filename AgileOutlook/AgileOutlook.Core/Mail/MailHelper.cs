﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

using Office = Microsoft.Office.Core;
using System.Reflection;
using System.Runtime.InteropServices;

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
    }
}

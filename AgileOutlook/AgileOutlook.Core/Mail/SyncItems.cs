using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook=Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;

namespace AgileOutlook.Core.Mail
{
    public class SyncItems
    {
        public List<SyncItem> Items;
        public List<SyncTime> SyncTimes;

        public delegate void ItemSyncEvent(object sender, SyncItem e);
        public event ItemSyncEvent ItemSync;

        public SyncItems()
        {
            Items = new List<SyncItem>();
            SyncTimes = new List<SyncTime>();
        }

        private string DirectoryName
        {
            get
            {
                string AppDataFolder = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData), "AgileOutlook");
                return AppDataFolder;
            }
        }

        public string FileName
        {
            get
            {
                return Path.Combine(DirectoryName, "NewMails.xml");
            }
        }

        private bool CheckFile()
        {
            try
            {
                if (!Directory.Exists(DirectoryName))
                {
                    Directory.CreateDirectory(DirectoryName);
                }
                if (!File.Exists(FileName))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlDeclaration xmlDeclaration =
                        xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    XmlElement xmlElement = xmlDoc.CreateElement("SyncDetails");
                    xmlDoc.AppendChild(xmlElement);
                    xmlDoc.InsertBefore(xmlDeclaration, xmlElement);
                    xmlDoc.Save(FileName);

                    if (!File.Exists(FileName))
                        return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Load()
        {
            Items.Clear();
            if (CheckFile())
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (xmlDoc != null)
                {
                    xmlDoc.Load(FileName);
                    XmlNode rootNode = xmlDoc.DocumentElement;

                    foreach (XmlNode node in rootNode)
                    {
                        if (node.Name == "synctimes")
                        {
                            foreach (XmlNode ItemNode in node)
                            {
                                SyncTime NewItem = new SyncTime();
                                if ((ItemNode.InnerText != null) &&
                                    (ItemNode.InnerText != string.Empty))
                                {
                                    NewItem.LatestTime =
                                        Convert.ToDateTime(ItemNode.InnerText);
                                }
                                if (ItemNode.Attributes["accountid"] != null)
                                {
                                    NewItem.AccountID =
                                        ItemNode.Attributes["accountid"].Value;
                                }
                                SyncTimes.Add(NewItem);
                                NewItem = null;
                            }
                        }
                        else if (node.Name == "syncitems")
                        {
                            foreach (XmlNode ItemNode in node)
                            {
                                SyncItem NewItem = new SyncItem();
                                NewItem.EntryID = ItemNode.InnerText.Trim();
                                if (ItemNode.Attributes["receivedtime"] != null)
                                {
                                    NewItem.ReceivedTime = Convert.ToDateTime(
                                        ItemNode.Attributes["receivedtime"].Value);
                                }
                                if (ItemNode.Attributes["sendersubj"] != null)
                                {
                                    NewItem.SenderSubject =
                                        ItemNode.Attributes["sendersubj"].Value;
                                }
                                if (ItemNode.Attributes["accountid"] != null)
                                {
                                    NewItem.AccountID =
                                        ItemNode.Attributes["accountid"].Value;
                                }
                                Items.Add(NewItem);
                                NewItem = null;
                            }
                        }
                    }
                    rootNode = null;
                    xmlDoc = null;
                }
            }
        }

        public void Save()
        {
            if (CheckFile())
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (xmlDoc != null)
                {
                    XmlDeclaration xmlDeclaration =
                        xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    XmlElement rootElement = xmlDoc.CreateElement("syncdetails");
                    xmlDoc.AppendChild(rootElement);

                    XmlElement syncTimesElement = xmlDoc.CreateElement("synctimes");
                    foreach (SyncTime item in SyncTimes)
                    {
                        XmlElement syncTimeElement = xmlDoc.CreateElement("synctime");
                        syncTimeElement.InnerText = item.LatestTime.ToString();

                        XmlAttribute accountIdAttribute =
                            xmlDoc.CreateAttribute("accountid");
                        accountIdAttribute.Value = item.AccountID;
                        syncTimeElement.Attributes.Append(accountIdAttribute);

                        syncTimesElement.AppendChild(syncTimeElement);
                    }
                    rootElement.AppendChild(syncTimesElement);

                    XmlElement ItemsElem = xmlDoc.CreateElement("syncitems");
                    foreach (SyncItem item in Items)
                    {
                        XmlElement syncItemElement = xmlDoc.CreateElement("item");

                        XmlAttribute receivedTimeAttribute =
                            xmlDoc.CreateAttribute("receivedtime");
                        receivedTimeAttribute.Value = item.ReceivedTime.ToString();
                        syncItemElement.Attributes.Append(receivedTimeAttribute);

                        XmlAttribute accountIdAttribute =
                            xmlDoc.CreateAttribute("accountid");
                        accountIdAttribute.Value = item.AccountID;
                        syncItemElement.Attributes.Append(accountIdAttribute);

                        XmlAttribute subjectAttribute =
                            xmlDoc.CreateAttribute("sendersubj");
                        subjectAttribute.Value = item.SenderSubject;
                        syncItemElement.Attributes.Append(subjectAttribute);

                        syncItemElement.InnerText = item.EntryID;
                        ItemsElem.AppendChild(syncItemElement);
                    }
                    rootElement.AppendChild(ItemsElem);

                    xmlDoc.InsertBefore(xmlDeclaration, rootElement);
                    xmlDoc.Save(FileName);
                    xmlDoc = null;
                }
            }
        }

        public bool Contains(SyncItem item)
        {
            foreach (SyncItem syncItem in Items)
            {
                if (item.EntryID == syncItem.EntryID)
                    return true;
                if ((item.ReceivedTime == syncItem.ReceivedTime) &&
                    (item.SenderSubject == syncItem.SenderSubject))
                    return true;
            }
            return false;
        }

        public void Add(SyncItem itemToAdd)
        {
            if (!Contains(itemToAdd))
            {
                Items.Add(itemToAdd);
                if (ItemSync != null)
                {
                    ItemSync(this, itemToAdd);
                }
            }
        }

        public void Remove(string entryID)
        {
            int RemovePosition = -1;
            foreach (SyncItem CurrentItem in Items)
            {
                if (CurrentItem.EntryID == entryID)
                {
                    RemovePosition = Items.IndexOf(CurrentItem);
                    break;
                }
            }
            if (RemovePosition != -1)
            {
                Items.RemoveAt(RemovePosition);
            }
        }

        public void RemoveByTime(DateTime dateTime, string accountID)
        {
            dateTime = dateTime.AddMinutes(-1);
            List<SyncItem> ItemsToRemove = new List<SyncItem>();
            foreach (SyncItem CurrentItem in Items)
            {
                if ((accountID == CurrentItem.AccountID) &&
                    (CurrentItem.ReceivedTime < dateTime))
                {
                    ItemsToRemove.Add(CurrentItem);
                }
            }

            foreach (SyncItem CurrentItem in ItemsToRemove)
            {
                Items.Remove(CurrentItem);
            }
        }

        public void InitializeSyncTimesAccounts(DateTime time,
            IMailHandler mailHandler)
        {
            SyncTimes.Clear();
            //Outlook.NameSpace nameSpace = null;
            //Outlook.Folders profileFolders = null;
            var profileFolders = mailHandler.GetWatchFolders();
            try
            {
                //if (mailHandler.OutlookApp == null) return;
                //nameSpace = OutlookApp.GetNamespace("MAPI");
                //if (nameSpace != null)
                //{
                //    profileFolders = nameSpace.Folders;
                //    int numberOfProfiles = profileFolders.Count;
                for (int i = 0; i < profileFolders.Count; i++)
                    {
                        var currProfile = profileFolders[i];
                        if (currProfile != null)
                        {
                            SyncTime NewTime = new SyncTime();
                            NewTime.AccountID = currProfile.EntryID;
                            NewTime.LatestTime = time;
                            SyncTimes.Add(NewTime);
                            //Marshal.ReleaseComObject(currProfile);
                        }
                    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //if (nameSpace != null)
                    //Marshal.ReleaseComObject(nameSpace);
                if (profileFolders != null)
                {
                    profileFolders.ToList().ForEach(m => Marshal.ReleaseComObject(m));
                }
                    //Marshal.ReleaseComObject(profileFolders);
            }
        }

        public void SetSyncTime(DateTime time, string accountID)
        {
            foreach (SyncTime item in SyncTimes)
            {
                if (item.AccountID == accountID)
                {
                    item.LatestTime = time;
                    RemoveByTime(time, accountID);
                    break;
                }
            }
            Save();
        }

    } 
}

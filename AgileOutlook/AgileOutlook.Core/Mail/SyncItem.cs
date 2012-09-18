using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileOutlook.Core.Mail
{
    public class SyncItem
    {
        public string EntryID;
        public DateTime ReceivedTime;
        public string SenderSubject;
        public string AccountID;

        public SyncItem()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Outlook;

namespace AgileOutlook.Core
{
    public class AOEventData<T>
    {
        public OutlookAddInBase AddIn { get; set; }

        public AOEventData(OutlookAddInBase source)
        {
            AddIn = source;
        }
    }
}

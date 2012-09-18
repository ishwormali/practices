using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace AgileOutlook.Core
{
    public interface IAgileOutlookAddIn
    {
        Outlook.Application OutlookApp{get;}
    }
}

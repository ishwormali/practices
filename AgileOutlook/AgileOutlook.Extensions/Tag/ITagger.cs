using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileOutlook.Core;

using Outlook = Microsoft.Office.Interop.Outlook;

using Office = Microsoft.Office.Core;

namespace AgileOutlook.Extensions.Tag
{
    public interface ITagger
    {
        void Startup(IAgileOutlookAddIn baseAddin, TagManager tagManager);

        void Shutdown();

        string TagSource { get; set; }

        IList<Tag> GetTags(AOMailItem mailItem);
    }
}

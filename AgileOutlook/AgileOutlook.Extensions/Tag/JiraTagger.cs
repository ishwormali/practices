using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AgileOutlook.Extensions.Tag
{
    public class JiraTagger:ITagger
    {
        TagManager tagManager;
        string regEx;
        Core.IAgileOutlookAddIn baseAddin;

        public void Startup(Core.IAgileOutlookAddIn baseAddin, TagManager tagManager)
        {
            this.baseAddin = baseAddin;
            this.tagManager = tagManager;
            regEx = @"CM-\d";
        }

        public void Shutdown()
        {
            
        }

        string tagSource = "Jira";
        public string TagSource
        {
            get
            {
                return tagSource;
            }
            set
            {
                tagSource = value;
            }
        }

        public IList<Tag> GetTags(Core.AOMailItem mailItem)
        {
            Regex rg = new Regex(regEx);
            var mtch=rg.Match(mailItem.OutlookMailItem.Subject);
            if (mtch.Success)
            {
                foreach (var grp in mtch.Groups)
                {
                       
                }
            }
            throw new NotImplementedException();
        }
    }
}

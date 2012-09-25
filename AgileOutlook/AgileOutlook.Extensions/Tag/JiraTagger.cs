using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.Composition;

namespace AgileOutlook.Extensions.Tag
{
    [Export(typeof(ITagger))]
    public class JiraTagger:ITagger
    {
        TagManager tagManager;
        string regEx;
        Core.IAgileOutlookAddIn baseAddin;

        public void Startup(Core.IAgileOutlookAddIn baseAddin, TagManager tagManager)
        {
            this.baseAddin = baseAddin;
            this.tagManager = tagManager;
            regEx = @"CM-\w+";
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
            var tags = new List<Tag>();

            Regex rg = new Regex(regEx);
            var mtches=rg.Matches(mailItem.OutlookMailItem.Subject);
            foreach (Match match in mtches)
            {
                foreach (Capture capture in match.Captures)
                {
                    tags.Add(new Tag(){TagSource = TagSource,TagName = capture.Value});
                }
            }

            return tags;
        }
    }
}

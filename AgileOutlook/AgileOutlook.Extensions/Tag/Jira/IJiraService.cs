using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileOutlook.Extensions.Tag.Jira
{
    public interface IJiraService
    {
        JiraInfo GetJiraByIssueNumber(string issueNumber);

    }
}

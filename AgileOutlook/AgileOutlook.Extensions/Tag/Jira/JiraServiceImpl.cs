using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileOutlook.Extensions.JiraSoapService;


namespace AgileOutlook.Extensions.Tag.Jira
{
    public class JiraServiceImpl:IJiraService
    {
        private JiraSoapServiceService client;

        public JiraServiceImpl()
        {

            client = new JiraSoapServiceService();
            
        }

        public JiraInfo GetJiraByIssueNumber(string issueNumber)
        {
            var token=client.login("i80398","984119031984Im");
            var ret=client.getIssueById(token,issueNumber);
            return new JiraInfo() { Description = ret.description };
            
        }
    }
}

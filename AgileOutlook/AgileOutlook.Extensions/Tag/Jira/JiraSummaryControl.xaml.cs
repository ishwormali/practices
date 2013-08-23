using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace AgileOutlook.Extensions.Tag.Jira
{
    /// <summary>
    /// Interaction logic for JiraSummaryControl.xaml
    /// </summary>
    public partial class JiraSummaryControl : UserControl
    {
        public Outlook.MailItem MailItem { get; set; }
        public JiraSummaryControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("message from button");
            IJiraService service = new JiraServiceImpl();
            //var a= service.GetJiraByIssueNumber("CM-2760");
            var a = service.GetJiraByIssueNumber("SIM-1");
            
            textBlock2.Text = a.Description;
        }
    }
}

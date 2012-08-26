using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook=Microsoft.Office.Interop.Outlook;

namespace AgileOutlook
{
    public partial class Form1 : Form
    {
        public Outlook.MailItem Mail { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var userProp=Mail.UserProperties.Find("AgiOutlook.Tag", true);
            if (userProp != null)
            {
                label1.Text = userProp.Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return;
            }

            var userProp = Mail.UserProperties.Find("AgiOutlook.Tag", true);
            if (userProp == null)
            {
                userProp = Mail.UserProperties.Add("AgiOutlook.Tag", Outlook.OlUserPropertyType.olText, Type.Missing, Type.Missing);

            }

            userProp.Value = textBox1.Text.Trim().ToUpperInvariant();
            //Mail.Save();
        }
    }
}

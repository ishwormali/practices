﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileOutlook.Core.Mail;
using System.Windows;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace AgileOutlook.Extensions.Tag.Jira
{
    [Export("MailFormRegion", typeof(IMailRegion))]
    class Test:IMailRegion
    {

        public ManifestOption GetManifestOption()
        {
            return new ManifestOption();
        }


        public UserControl GetView(Microsoft.Office.Interop.Outlook.MailItem mailItem)
        {
            return new JiraSummaryControl();
        }
    }
}

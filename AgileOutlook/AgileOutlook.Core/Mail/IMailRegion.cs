using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Outlook = Microsoft.Office.Interop.Outlook;

using Office = Microsoft.Office.Core;
using System.Windows.Controls;

namespace AgileOutlook.Core.Mail
{
    public interface IMailRegion
    {
        ManifestOption GetManifestOption();

        UserControl GetView(Outlook.MailItem mailItem);
    }
}

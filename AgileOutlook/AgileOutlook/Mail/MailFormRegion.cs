using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using AgileOutlook.Core.Mail;

namespace AgileOutlook.Mail
{
    partial class MailFormRegion
    {
        #region Form Region Factory

        
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("AgileOutlook.MailFormRegion")]
        public partial class MailFormRegionFactory
        {

            
            [ImportMany("MailFormRegion",typeof(IMailRegion))]
            public IList<IMailRegion> MailRegions { get; set; }
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void MailFormRegionFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
                if (!MailRegions.Any())
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void MailFormRegion_FormRegionShowing(object sender, System.EventArgs e)
        {
            
        }

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void MailFormRegion_FormRegionClosed(object sender, System.EventArgs e)
        {
            
        }

        private MailFormRegionFactory GetFactory()
        {
            return (MailFormRegionFactory) this.Factory;
        }
    }
}

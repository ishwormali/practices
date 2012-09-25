using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileOutlook.Core;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.ComponentModel.Composition;
using Office = Microsoft.Office.Core;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using AgileOutlook.Core.Mail;

namespace AgileOutlook.Extensions.Tag
{

    [Export(typeof(IAOMailItemExtension))]
    public class TagManager : IAOMailItemExtension
    {
       

        public TagManager()
        {
            
        }

        public void Startup(IAgileOutlookAddIn baseAddin,IMailHandler mailHandler)
        {
            mailHandler.MailReceived += new MailReceivedEvent(Mail_Received);
        }

        void Mail_Received(object sender, MailReceivedEventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine(
                String.Format("{0} ->{1},from:{2},subject:{3},{4}", e.Item.ReceivedTime, e.Item.EntryID,e.MailItem.OutlookMailItem.SenderName,e.MailItem.OutlookMailItem.Subject, Environment.NewLine));
            
            
            var newTags = new List<Tag>();

            foreach (var tagger in Taggers)
            {
                var tgs=tagger.GetTags(e.MailItem);
                newTags.AddRange(tgs);    
            }
            if (newTags.Any())
            {
                var prop = MailHelper.GetOrCreateUserProperty(e.MailItem.OutlookMailItem, "TagManager.Tags",
                                                          OlUserPropertyType.olEnumeration);

                var existingTags = prop.Value as IList<Tag>;
                if (existingTags == null)
                {
                    existingTags = new List<Tag>();
                }

                var newFilteredTags = newTags.Where(
                m =>
                !existingTags.Any(
                    ex =>
                    string.Compare(m.TagName, ex.TagName, StringComparison.OrdinalIgnoreCase) == 0 &&
                    string.Compare(m.TagSource, m.TagName, StringComparison.OrdinalIgnoreCase) == 0));

                foreach (var newFilteredTag in newFilteredTags)
                {
                    existingTags.Add(newFilteredTag);
                }
            }
            
        }

        public void ShutDown()
        {

        }

        public IEnumerable<Office.CommandBarControl> OnMailItemContextMenu(Office.CommandBar CommandBar, Office.CommandBarPopup agileCommand, IEnumerable<Outlook.MailItem> selectedMailItems)
        {
            var taggerMenuItem = (Office.CommandBarButton)agileCommand.Controls.Add(Office.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);

            taggerMenuItem.Caption = "Tag";
            
            taggerMenuItem.Click += new Office._CommandBarButtonEvents_ClickEventHandler(taggerMenuItem_Click);
            return new List<Office.CommandBarControl>() { taggerMenuItem };

        }



        void taggerMenuItem_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
        {

        }

        [ImportMany(typeof(ITagger))]
        public IEnumerable<ITagger> Taggers;
    }
}

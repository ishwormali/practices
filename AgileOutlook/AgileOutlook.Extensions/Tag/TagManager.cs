using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AgileOutlook.Core;
using Microsoft.Office.Interop.Outlook;
using log4net;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.ComponentModel.Composition;
using Office = Microsoft.Office.Core;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using AgileOutlook.Core.Mail;
using Exception = System.Exception;

namespace AgileOutlook.Extensions.Tag
{

    [Export(typeof(IAOMailItemExtension))]
    public class TagManager : IAOMailItemExtension
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public TagManager()
        {
            
        }

        public void Startup(IAgileOutlookAddIn baseAddin,IMailHandler mailHandler)
        {
            foreach (var tagger in Taggers)
            {
                tagger.Startup(baseAddin, this);

            }
            mailHandler.MailReceived += new MailEvent(Mail_Received);
            mailHandler.MailSent += new MailEvent(Mail_Sent);
        }

        void Mail_Received(object sender, MailReceivedEventArgs e)
        {

            //Logger.Log.DebugFormat("{0} ->{1},from:{2},subject:{3},{4}", e.Item.ReceivedTime, e.Item.EntryID,
            //           e.MailItem.OutlookMailItem.SenderName, e.MailItem.OutlookMailItem.Subject, Environment.NewLine);

            TagMailItem(e.MailItem);
            
        }

        void Mail_Sent(object sender, MailReceivedEventArgs e)
        {

            //Logger.Log.DebugFormat("{0} ->{1},from:{2},subject:{3},{4}", e.Item.ReceivedTime, e.Item.EntryID,
            //           e.MailItem.OutlookMailItem.SenderName, e.MailItem.OutlookMailItem.Subject, Environment.NewLine);

            TagMailItem(e.MailItem);

        }

        private void TagMailItem(AOMailItem mailItem)
        {
            var newTags = new List<Tag>();

            foreach (var tagger in Taggers)
            {
                var tgs = tagger.GetTags(mailItem);
                if (tgs != null && tgs.Any())
                {
                    newTags.AddRange(tgs);
                }

            }

            if (newTags.Any())
            {
                try
                {
                    var existingTags = GetTags(mailItem.OutlookMailItem);

                    var prop = MailHelper.GetOrCreateUserProperty(mailItem.OutlookMailItem, PropName,
                                                          OlUserPropertyType.olText);

                    existingTags = existingTags ?? new List<Tag>();

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

                    var existingTagsString = string.Join(";", existingTags.Select(m => ParseToString(m)));

                    MailHelper.SetUserProperty(mailItem.OutlookMailItem, PropName, existingTagsString);
                    mailItem.OutlookMailItem.Save();
                    Log.DebugFormat("Tagging Mail Item as:{0}, Sent By:{1}, To:{2}, Subject:{3}", existingTagsString,
                                    mailItem.OutlookMailItem.SenderName, mailItem.OutlookMailItem.ReceivedByName, mailItem.OutlookMailItem.Subject);

                }
                catch (Exception ex)
                {

                    Log.Error(ex.Message, ex);
                }

            }
            else
            {
                Log.DebugFormat("No tag found Sent By:{0}, To:{1}, Subject:{2}",
                                    mailItem.OutlookMailItem.SenderName, mailItem.OutlookMailItem.ReceivedByName, mailItem.OutlookMailItem.Subject);

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

        public IList<Tag> GetTags(Outlook.MailItem mailItem)
        {
            var existingTags=new List<Tag>();
            if(!MailHelper.HasUserProperty(mailItem,PropName))
            {
                return null;
            }

            var propValue=MailHelper.GetUserProperty(mailItem, PropName);
            var propString = propValue != null ? propValue.ToString() : string.Empty;

            propString.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(delegate(string str)
                                                              {
                                                                  var strBroken = str.Split(new string[]{"."},StringSplitOptions.RemoveEmptyEntries);
                                                                  var tg = new Tag()
                                                                               {
                                                                                   TagSource = strBroken[0],
                                                                                   TagName = strBroken[1]
                                                                               };
                                                                  existingTags.Add(tg);

                                                              });
            return existingTags;
        }

        public string ParseToString(Tag tag)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}.{1}",
                                                                           tag.TagSource, tag.TagName);
        }

        [ImportMany(typeof(ITagger))]
        public IEnumerable<ITagger> Taggers;

        public string PropName{
            get
            {
                return "TagManager.Tags";
            }
        }
        //[Import(typeof(ITagger))]
        //public ITagger Tagger;

    }
}

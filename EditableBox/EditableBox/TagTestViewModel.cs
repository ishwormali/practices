using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cinch;

namespace EditableBox
{
    class TagTestViewModel:ViewModelBase
    {
        private TagCollection tags;

        public TagCollection Tags
        {
            get 
            {
                if (tags == null)
                {
                    tags = new TagCollection();
                }

                return tags; 
            }
            set 
            { 
                tags = value; 
                NotifyPropertyChanged("Tags"); 
            }
        }

        private Tag importantTag=new Tag() { TagSource = "Jira", TagName = "11111" };

        public Tag ImportantTag
        {
            get { return importantTag; }
            set { importantTag = value; NotifyPropertyChanged("ImportantTag"); }
        }
        
        
        public TagTestViewModel()
        {
            Tags.Add(new Tag() {TagName="CM-1401",TagSource="Jira" });
            Tags.Add(new Tag() { TagName = "CM-967", TagSource = "Jira" });
            Tags.Add(new Tag() { TagName = "CM-2221", TagSource = "Jira" });
            Tags.Add(new Tag() { TagName = "CM-2323", TagSource = "Jira" });
            Tags.Add(new Tag() { TagName = "CM-1234", TagSource = "Jira" });
            Tags.Add(new Tag() { TagName = "CM-2222", TagSource = "Jira" });
            Tags.Add(new Tag() { TagName = "CM-3333", TagSource = "Jira" });
            Tags.Add(ImportantTag);

            QueryTag = new SimpleCommand<object, object>(
            delegate(object p)
            {
                System.Diagnostics.Debug.WriteLine(p);

            }

            );
            //System.Windows.Interactivity.EventTrigger
            
        }

        public SimpleCommand<object, object> QueryTag{get;set;}
        
    }
}

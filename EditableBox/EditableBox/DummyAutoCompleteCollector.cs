using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditableBox.Controls;
namespace EditableBox
{
    public class DummyAutoCompleteCollector:IAutoCompleteDataCollector
    {
        public void GatherData(AutoCompleteDataArgs arg)
        {
            var existingText = (arg.ExistingData != null ? ((Tag) arg.ExistingData).TagName : string.Empty);
            existingText = existingText ?? string.Empty;
            var tempList = DummyList.Where(m => m.TagName.Substring(0, (existingText.Length > m.TagName.Length ? m.TagName.Length : existingText.Length)).Equals(existingText, StringComparison.OrdinalIgnoreCase));
            arg.PopulateData(tempList);
        }

        static DummyAutoCompleteCollector()
        {

           
            
        }


        public static IList<Tag> DummyList
        {
            get
            {
                return new List<Tag>(){
                new Tag() { TagName = "CM-1401", TagSource = "Jira" },
                new Tag() { TagName = "CM-967", TagSource = "Jira" },
                new Tag() { TagName = "CM-2221", TagSource = "Jira" },
                new Tag() { TagName = "CM-2323", TagSource = "Jira" },
                new Tag() { TagName = "CM-1234", TagSource = "Jira" },
            new Tag() { TagName = "CM-2222", TagSource = "Jira" },
            new Tag() { TagName = "CM-1243", TagSource = "Jira" },
            new Tag() { TagName = "CM-1253", TagSource = "Jira" },
            new Tag() { TagName = "CM-1263", TagSource = "Jira" },
            new Tag() { TagName = "CM-1261", TagSource = "Jira" },
            new Tag() { TagName = "CM-1262", TagSource = "Jira" },
            new Tag() { TagName = "CM-1263", TagSource = "Jira" },
            new Tag() { TagName = "CM-1264", TagSource = "Jira" },
            new Tag() { TagName = "CM-1265", TagSource = "Jira" }
                
            };
            }
        }
    }
}

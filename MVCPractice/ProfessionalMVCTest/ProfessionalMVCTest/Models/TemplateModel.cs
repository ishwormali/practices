using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Models
{
    public class TemplateModel
    {
     
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ModelKey { get; set; }

        public string Prop1 { get; set; }

         [ScaffoldColumn(false)]
        public string HiddenProperty { get; set; }

        [Editable(false)]
           [DataType(DataType.Url)]
           [UIHint("CustomPropertyTemplate")]
        
         public string HiddenProperty2 { get; set; }

        public List<string> SomeCollection { get; set; }
    }
}
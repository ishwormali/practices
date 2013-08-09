using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProfessionalMVCTest.Models
{
    public class PersonalDetail
    {
        

       [DisplayName("Last Name")]
        public string LastName { get; set; }

       [Display(Name = "My First Name", Order = 9999, Prompt = "watermark")]
       public string FirstName { get; set; }

        [ScaffoldColumn(false)]
        
       public int UserId { get; set; }

        [Editable(false, AllowInitialValue = false)]
        [DataType(DataType.Url)]
        public string CreditCard { get; set; }

        //[DisplayFormat(NullDisplayText="",HtmlEncode=false,ConvertEmptyStringToNull=true,ApplyFormatInEditMode=true,DataFormatString="dd/mm/yyyy")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [DefaultValue(0)]
        public decimal Amount { get; set; }


        public DateTime DateOfBirth { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProfessionalMVCTest.Models
{
    public class ModelBinderModel
    {
        public ModelBinderModel()
        {

        }

        [DisplayFormat(ConvertEmptyStringToNull=false)]
        public string ModelKey { get; set; }

        public string Prop1 { get; set; }


        public ModelBinderSubModel SubModel { get; set; }
        
    }

    public class ModelBinderSubModel
    {
        public string Key { get; set; }

        public string Prop1 { get; set; }

    }
}
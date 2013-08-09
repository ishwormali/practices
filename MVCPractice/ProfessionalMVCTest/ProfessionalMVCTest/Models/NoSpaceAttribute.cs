using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Models
{
    public class NoSpaceAttribute:ValidationAttribute,IClientValidatable
    {
        /// <summary>
        /// Indicates that the value should be trimmed first on both end before determining if there are any additional spaces.
        /// Defaults to true.
        /// </summary>
        public bool TrimFirst { get; set; }
        public NoSpaceAttribute()
            : base("{0} Should not contain any space")
        {
            this.TrimFirst = true;
        }

        public override bool IsValid(object value)
        {
            if (value!=null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                var stringValue = value.ToString();
                stringValue = (TrimFirst ? stringValue.Trim() : stringValue);

                return !stringValue.Contains(" ");

            }

            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("trimfirst", TrimFirst);
            rule.ValidationParameters.Add("trimsecond", true);
            rule.ValidationType = "nospace";
            yield return rule;
            
        }

    }

    //public class NoSpaceAttribute:ValidationAttribute
    //{
    //    /// <summary>
    //    /// Indicates that the value should be trimmed first on both end before determining if there are any additional spaces.
    //    /// Defaults to false.
    //    /// </summary>
    //    public bool TrimFirst { get; set; }
    //    public NoSpaceAttribute()
    //        : base("{0} Should not contain any space")
    //    {

    //    }

    //    public override bool IsValid(object value)
    //    {
    //        if (value!=null && !string.IsNullOrWhiteSpace(value.ToString()))
    //        {
    //            var stringValue = value.ToString();
    //            stringValue = (TrimFirst ? stringValue.Trim() : stringValue);

    //            return !stringValue.Contains(" ");

    //        }

    //        return true;
    //    }

    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        return base.IsValid(value, validationContext);
    //    }

    //    public override string FormatErrorMessage(string name)
    //    {
    //        return base.FormatErrorMessage(name);
    //    }

    //    public override bool RequiresValidationContext
    //    {
    //        get
    //        {
    //            return base.RequiresValidationContext;
    //        }
    //    }

    //}


}



        
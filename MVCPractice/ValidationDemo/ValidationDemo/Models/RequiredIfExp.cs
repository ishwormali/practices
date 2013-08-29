using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ValidationDemo.Models
{
    public class RequiredIfExp:ValidationAttribute,IClientValidatable
    {
        string expression;

        public RequiredIfExp(string exp)
        {
            this.expression = exp;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return null;
            return base.IsValid(value, validationContext);
        }


        //public override bool IsValid(object value)
        //{
        //    return base.IsValid(value);
        //}


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var validation=new ModelClientValidationRule(){

                ErrorMessage=FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType="requiredifexp",
                

            };

            validation.ValidationParameters["expression"] = expression;
            yield return validation;
        }
    }
}
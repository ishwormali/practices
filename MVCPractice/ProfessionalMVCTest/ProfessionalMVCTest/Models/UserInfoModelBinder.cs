using ProfessionalMVCTest.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Models
{
    public class UserInfoModelBinder:IModelBinder
    {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }
           
            if (bindingContext.ModelType!=typeof(UserInfo))
            {
                throw new InvalidOperationException("UserInfoModelBinder is only supposed to bind UserInfo type");
            }

            if (!string.IsNullOrWhiteSpace(bindingContext.ModelName) && !bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName))
            {
                if (!bindingContext.FallbackToEmptyPrefix)
                {
                    return null;
                }

                bindingContext = new ModelBindingContext()
                {
                    FallbackToEmptyPrefix = true,
                    ModelMetadata = bindingContext.ModelMetadata,
                    ModelState = bindingContext.ModelState,
                    PropertyFilter = bindingContext.PropertyFilter,
                    ValueProvider = bindingContext.ValueProvider
                };
            }

            bindingContext.ModelMetadata.Model = new UserInfo();
            foreach (var prop in typeof(UserInfo).GetProperties(System.Reflection.BindingFlags.Public| System.Reflection.BindingFlags.Instance))
            {
                var propName = prop.Name;
                propName = !string.IsNullOrWhiteSpace(bindingContext.ModelName) ? bindingContext.ModelName + "." + propName : propName;

            }

            return null;

        }
    }
}
using ProfessionalMVCTest.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
           
            //if (bindingContext.ModelType!=typeof(UserInfo))
            //{
            //    throw new InvalidOperationException("UserInfoModelBinder is only supposed to bind UserInfo type");
            //}

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

            var propertyCollection = GetProperties(bindingContext);

            foreach (var prop in propertyCollection)
            {
                
                var propName =CreateSubPropertyName(bindingContext.ModelName, prop.Name);

                var valueResult=bindingContext.ValueProvider.GetValue(propName);
                if (valueResult==null)
                {
                    var propertyMetadata = bindingContext.PropertyMetadata[prop.Name];
                    
                    //ModelValidator requiredValidator = ModelValidatorProviders.Providers.GetValidators(propertyMetadata, controllerContext).Where(v => v.IsRequired).FirstOrDefault();

                    if (propertyMetadata.IsRequired)
                    {

                        bindingContext.ModelState.AddModelError(propName, string.Format(CultureInfo.InvariantCulture, "{0} is Required",propName));
                    }
                    
                }
                else
                {
                    try
                    {
                        if (!prop.IsReadOnly)
                        {
                            var convertedValue = valueResult.ConvertTo(prop.PropertyType);
                            prop.SetValue(bindingContext.ModelMetadata.Model, convertedValue);
                        }

                        bindingContext.ModelState.SetModelValue(propName, valueResult);
                    }
                    catch (Exception ex)
                    {

                        bindingContext.ModelState.AddModelError(propName, ex);
                    }
                    
                }
            }


            foreach (ModelValidationResult validationResult in ModelValidator.GetModelValidator(bindingContext.ModelMetadata, controllerContext).Validate(null))
            {
                string subPropertyName = CreateSubPropertyName(bindingContext.ModelName, validationResult.MemberName);

                //if (!startedValid.ContainsKey(subPropertyName))
                //{
                //    startedValid[subPropertyName] = bindingContext.ModelState.IsValidField(subPropertyName);
                //}

                if (bindingContext.ModelState.IsValidField(subPropertyName))
                {
                    bindingContext.ModelState.AddModelError(subPropertyName, validationResult.Message);
                }
            }
        
            return bindingContext.Model;

        }

        protected  string CreateSubPropertyName(string prefix, string propertyName)
        {
            if (String.IsNullOrEmpty(prefix))
            {
                return propertyName;
            }
            else if (String.IsNullOrEmpty(propertyName))
            {
                return prefix;
            }
            else
            {
                return prefix + "." + propertyName;
            }
        }

        public IEnumerable<PropertyDescriptor> GetProperties(ModelBindingContext context)
        {
            var propertyCollection = new AssociatedMetadataTypeTypeDescriptionProvider(typeof(UserInfo)).GetTypeDescriptor(typeof(UserInfo)).GetProperties();
            var result = from PropertyDescriptor propDesc in propertyCollection where CanUpdateProperty(propDesc, context.PropertyFilter) select propDesc;
            return result;
        }

        public bool CanUpdateProperty(PropertyDescriptor prop, Predicate<string> propertyFilter)
        {
            if (prop.IsReadOnly || !propertyFilter(prop.Name))
            {
                return false;
            }

            return true;
        }
    }
     
     
}
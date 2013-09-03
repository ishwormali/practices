using MVCDemo.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo2.Models
{
    public class UserInfoModelBinder:IModelBinder
    {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
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

            var obj = new UserInfo();
            bindingContext.ModelMetadata.Model = obj;

            var propertyCollection = GetProperties(bindingContext);

            foreach (var prop in propertyCollection)
            {
                var propName = CreateSubPropertyName(bindingContext.ModelName, prop.Name);
                var valueResult = bindingContext.ValueProvider.GetValue(propName);
                var propertyMetadata = bindingContext.PropertyMetadata[prop.Name];

                if (valueResult != null)
                {

                    try
                    {
                        if (propertyMetadata.IsRequired && string.IsNullOrWhiteSpace(valueResult.AttemptedValue))
                        {
                            bindingContext.ModelState.AddModelError(propName, string.Format(CultureInfo.InvariantCulture, "{0} is Required", propertyMetadata.GetDisplayName()));
                            //bindingContext.ModelState.AddModelError(propName, string.Format(CultureInfo.InvariantCulture, "{0} is Required", prop.Name));

                        }
                        else
                        {
                            var propValue = valueResult.ConvertTo(prop.PropertyType);
                            prop.SetValue(obj, propValue);
                            //bindingContext.ModelState.SetModelValue(propName, valueResult);
                        }
                       
                    }
                    catch (Exception ex)
                    {

                        bindingContext.ModelState.AddModelError(propName, string.Format("The value {0} is invalid", valueResult.AttemptedValue));

                    }

                }
                else
                {
                    

                    //ModelValidator requiredValidator = ModelValidatorProviders.Providers.GetValidators(propertyMetadata, controllerContext).Where(v => v.IsRequired).FirstOrDefault();

                    if (propertyMetadata.IsRequired)
                    {

                        bindingContext.ModelState.AddModelError(propName, string.Format(CultureInfo.InvariantCulture, "{0} is Required", propName));
                    }

                }


                
            }

            foreach (ModelValidationResult validationResult in ModelValidator.GetModelValidator(bindingContext.ModelMetadata, controllerContext).Validate(null))
            {
                string subPropertyName = CreateSubPropertyName(bindingContext.ModelName, validationResult.MemberName);

                if (bindingContext.ModelState.IsValidField(subPropertyName))
                {
                    bindingContext.ModelState.AddModelError(subPropertyName, validationResult.Message);
                }
            }

            return obj;
        }

        protected string CreateSubPropertyName(string prefix, string propertyName)
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

        /*
        //phase 2
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
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

            var obj = new UserInfo();

            var properties = typeof(UserInfo).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var prop in properties)
            {
                var key =CreateSubPropertyName(bindingContext.ModelName, prop.Name);
                var valueResult = bindingContext.ValueProvider.GetValue(key);

                if (valueResult != null)
                {
                    var propValue = valueResult.ConvertTo(prop.PropertyType);
                    prop.SetValue(obj, propValue);
                    
                }
            }

            return obj;
        }

        protected string CreateSubPropertyName(string prefix, string propertyName)
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

        */

        /* //Phase 1
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }

            //var userId = controllerContext.HttpContext.Request[bindingContext.ModelName];
            ////var userId = controllerContext.HttpContext.Request["user"];
            //if (!string.IsNullOrWhiteSpace(userId))
            //{
                
            //    var user = UserInfo.Users.FirstOrDefault(m => m.Id ==Convert.ToInt32( userId));
            //    return user;
            //}


            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueResult != null)
            {
                var userId = (int)valueResult.ConvertTo(typeof(int));
                var user = UserInfo.Users.FirstOrDefault(m => m.Id == userId);
                return user;
            }

            return null;
        }
        */
    }
}
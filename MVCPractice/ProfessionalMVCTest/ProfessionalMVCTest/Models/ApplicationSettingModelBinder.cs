using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Models
{
    public class ApplicationSettingModelBinder:IModelBinder
    {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = new ApplicationSetting();
            model.ApplicationName=ConfigurationManager.AppSettings["ApplicationName"];
            model.Version = ConfigurationManager.AppSettings["Version"];
            model.ReleasedDate = ConfigurationManager.AppSettings["ReleasedDate"];
            model.IsOffline =Convert.ToBoolean(ConfigurationManager.AppSettings["IsOffline"]);

            return model;
        }
    }

    public class ApplicationSetting
    {
        
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string ReleasedDate { get; set; }
        public bool IsOffline { get; set; }
    }

    public class ApplicationSettingBinderAttribute : CustomModelBinderAttribute
    {

        public override IModelBinder GetBinder()
        {
            return new ApplicationSettingModelBinder();
        }
    }
}
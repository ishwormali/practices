using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Models
{
    public class AppSettingValueProvider:NameValueCollectionValueProvider
    {
       
        public AppSettingValueProvider(ControllerContext controllerContext)
            : this(controllerContext,CultureInfo.CurrentCulture)
        {
        }

        // For unit testing
        internal AppSettingValueProvider(ControllerContext controllerContext,CultureInfo culture)
            : base(ConfigurationManager.AppSettings, culture)
        {
        }

        //public override ValueProviderResult GetValue(string key)
        //{
        //    var ret = base.GetValue(key);
        //    return ret;// base.GetValue(key);
        //}

        //public override bool ContainsPrefix(string prefix)
        //{
        //    var ret= base.ContainsPrefix(prefix);
        //    return ret;
        //}
        //public bool ContainsPrefix(string prefix)
        //{
            
        //    var hasPrefix=!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings[prefix]);
        //    //fallback to empty prefix
        //    if (!hasPrefix)
        //    {
        //        var containsDot = prefix.Contains(".");
        //        if (containsDot)
        //        {
        //            var strippedPrefix = prefix.Substring(prefix.LastIndexOf("."));
    
        //        }

                
    
        //    }

        //    return true;


        //}

        //public ValueProviderResult GetValue(string key)
        //{
        //    var actValue = ConfigurationManager.AppSettings[key];
        //    if (string.IsNullOrWhiteSpace(actValue))
        //    {
        //        return null;
        //    }

        //    return new ValueProviderResult(actValue, actValue, CultureInfo.InvariantCulture);            

        //}
    }

    public class AppSettingValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new AppSettingValueProvider(controllerContext);
        }
    }

}
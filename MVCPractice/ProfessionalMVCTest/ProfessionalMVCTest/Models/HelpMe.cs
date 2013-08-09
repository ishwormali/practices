using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace TestApp.Models
{
    public static class HelpMe
    {
        public static string GenericMethod<T>(T prop)
        {
            //do something
            return prop.ToString();
        }

        public static HelperResult RenderDelegate(Func<string, HelperResult> del)
        {
            return del("some thing to bold passed in parameter");
        }
    }
}
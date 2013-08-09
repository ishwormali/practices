using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfessionalMVCTest.Models
{
    public abstract class CustomView<T> : System.Web.Mvc.WebViewPage<T>
    {
        public string SomeProperty { get; set; }

        public IHtmlString SomeFunction()
        {
            return new System.Web.Mvc.MvcHtmlString("some function value");
        }


    }
}
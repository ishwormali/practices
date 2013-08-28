using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Models
{
    public class UserAgentSelectorAttribute:ActionMethodSelectorAttribute
    {
        private string userAgent;
        public UserAgentSelectorAttribute(string userAgent)
        {
            this.userAgent = userAgent;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.UserAgent.IndexOf(userAgent,StringComparison.OrdinalIgnoreCase)>=0;

        }
    }
}
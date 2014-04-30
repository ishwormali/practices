using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace GrabMyContent.Models
{
    public class RequestKeyValidationActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var requestKey=filterContext.HttpContext.Request.Params["RequestKey"];
            if (string.IsNullOrWhiteSpace(requestKey)||!requestKey.Equals(System.Configuration.ConfigurationManager.AppSettings["RequestKey"]))
            {
                DealWithInvalidRequest(filterContext);
            }
            
        }

        private void DealWithInvalidRequest(ActionExecutingContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();

        }
    }
}
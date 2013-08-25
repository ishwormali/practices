using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Models
{
    public class CustomControllerFactory:DefaultControllerFactory
    {
        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            
            var controllerType = typeof(CustomControllerFactory).Assembly.GetTypes().
                Where(m=>typeof(IController).IsAssignableFrom(m)).
                FirstOrDefault(m => m.Name.Equals(string.Format("{0}MyController", controllerName),StringComparison.OrdinalIgnoreCase));
            if (controllerType != null)
            {
                return (IController)Activator.CreateInstance(controllerType);
            }

            return null;
        }

        
    }
}
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCDemo.Models
{
    public class CustomControllerFactory:DefaultControllerFactory
    {
        
        public override IController CreateController(RequestContext requestContext, string controllerName)
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


//IKernel kernel;

//public CustomControllerFactory(IKernel kernel)
//{
//    this.kernel = kernel;
//}





//var controller = kernel.Get(controllerType);
//if (controller != null)
//{
//    return (IController)controller;
//}

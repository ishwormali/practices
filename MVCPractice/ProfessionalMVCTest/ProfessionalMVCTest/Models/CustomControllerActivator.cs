using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProfessionalMVCTest.Models
{
    public class CustomControllerActivator//:IControllerActivator
    {

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            //return (IController)Activator.CreateInstance(controllerType);
            var controller=(IController)DependencyResolver.Current.GetService(controllerType);
            return controller;
        }
    }
}
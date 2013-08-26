using MVCDemo2.Controllers;
using MVCDemo2.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCDemo2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var kernel = new StandardKernel();
            kernel.Bind<INameFormatter>().To<NameFormatter>();
            kernel.Bind<IBlobService>().To<AmazonBlobService>();
            kernel.Bind<PersonBlobController>().To<PersonBlobController>();
            DependencyResolver.SetResolver(t => {
                return kernel.TryGet(t);
            }, t => { 
                return kernel.GetAll(t); 
            });
        }
    }
}
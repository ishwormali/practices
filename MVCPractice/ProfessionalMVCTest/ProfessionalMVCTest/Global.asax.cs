using Ninject;
using ProfessionalMVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProfessionalMVCTest
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
            AuthConfig.RegisterAuth();
            
            /*
             * controller factory
            //method 1
            //ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
            
            //method 2
            //DependencyResolver.SetResolver((t) => {
            //    if (typeof(IControllerFactory).IsAssignableFrom(t))
            //    {
            //        return new CustomControllerFactory();
            //    }

            //    return null;
            //}, t => 
            //{ 
            //    return new List<object>(); 
            //});
            
            //method 3
            //var kernel = new StandardKernel();
            //kernel.Bind<IControllerFactory>().To<CustomControllerFactory>();
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            */
            
        }
    }

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }
    }



}
using MVCDemo.Controllers;
using MVCDemo.Models;
using MVCDemo.Models.DB;
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

namespace MVCDemo
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


            ModelBinders.Binders.Add(typeof(UserInfo), new UserInfoModelBinder());

            //ModelBinderProviders.BinderProviders.Add(new UserInfoModelBinderProvider());



            //var kernel = new StandardKernel();
            //kernel.Bind<IModelBinderProvider>().To<UserInfoModelBinderProvider>();
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));




            //value provider factories
            //ValueProviderFactories.Factories.Add(new AppSettingValueProviderFactory());
            //var kernel = new StandardKernel();
            //kernel.Bind<ValueProviderFactory>().To<AppSettingValueProviderFactory>();
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
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
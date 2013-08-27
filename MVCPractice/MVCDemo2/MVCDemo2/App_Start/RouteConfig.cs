using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCDemo2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*  
            //using constraints
            
            routes.MapRoute("DinasorusRoute", "{college}/{year}/Students", new
            {
                controller = "College",
                action = "GrandPas"
                //, extraParam = "this is extra param" 
            }, new { year = @"(18[0-9]{2})" });

            
            routes.MapRoute("CollegeRoute", "{college}/{year}/Students", new
            {
                controller = "College",
                action = "Students"
                //, extraParam = "this is extra param" 
            });
          
            
            routes.MapRoute(
               name: "RouteTestModified",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "NonIndex", id = UrlParameter.Optional }
           );
             */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
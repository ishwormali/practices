using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class RouteTestController : Controller
    {
        //
        // GET: /RouteTest/

        public ActionResult Index(string id,string a, string b)
        {
            return View();
        }

        public ActionResult NonIndex()
        {
            return View();
        }

    }
}

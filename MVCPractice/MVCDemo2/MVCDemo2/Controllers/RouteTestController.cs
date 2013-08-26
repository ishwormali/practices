using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo2.Controllers
{
    public class RouteTestController : Controller
    {
        //
        // GET: /RouteTest/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NonIndex()
        {
            return View();
        }

    }
}

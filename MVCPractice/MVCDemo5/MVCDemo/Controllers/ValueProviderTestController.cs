using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo2.Controllers
{
    public class ValueProviderTestController : Controller
    {
        //
        // GET: /ValueProviderTest/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AppSettings(ApplicationSetting setting)
        {
            return View(setting);
        }

    }
}

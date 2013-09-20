using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPrep.Controllers
{
    public class TestViewController : Controller
    {
        //
        // GET: /TestView/

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetPartialView()
        {
            return PartialView("PartialView");
        }

        public ViewResult AsMainView()
        {
            return View("PartialView");
        }

    }
}

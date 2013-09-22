using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPrep.Controllers
{

    //[HandleError()]
    [HandleError(View = "CustomErrPage")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PageInspector()
        {
            return View();
        }

        public ActionResult ThrowError()
        {
            throw new ApplicationException("Deliberately thrown the error.");
        }

        

        public ActionResult ThrowErrorStatus(int error)
        {
            throw new HttpException(error,string.Empty);
        }

        public string Error505Result()
        {
            return "this is error 500 result";
        }
        
    }
}

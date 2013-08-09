using ProfessionalMVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult TemplatePractice()
        {
            return View();
        }

        public ActionResult RazorTest()
        {
            return View();
        }

        public ActionResult CollectionBindingTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CollectionBindingTest(int[] coll)
        {

            return View();
        }

        

        [HttpPost]
        public ActionResult CollectionBindingTestWithEnum(IEnumerable<string> coll)
        {

            return View("CollectionBindingTest");
        }

        public ActionResult ModelBindingTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModelBindingTest(ModelBinderModel model)
        {
            var i=Convert.ToInt16(Request["some key"]);

            return View(model);
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            //Response.SetCookie(new HttpCookie("somecookie", "secret.shhhhhhhhhhhhhh"));
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

        public ViewResult TestPage()
        {
            //var str = string.Format("some message", 1, 2);
            //var str2 = string.Format("{0} some message");
            
            return View();
            
        }

        public ViewResult ValidationTest()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ValidationTest(Person perso)
        {
            
            return View();
        }


        public ActionResult DataAnnotationsPractice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataAnnotationsPractice(PersonalDetail model)
        {
            return View(model);
        }

        public JsonResult CheckUserId(string userId /*field name */)
        {
            var isvalid = true;//check if the given userid already exists in db?
            return Json(isvalid, JsonRequestBehavior.AllowGet);
        }

        //[NonAction]
        public void PublicAction()
        {
            var temp = Request;
        }

        public JavaScriptResult GetJS()
        {
            
            return JavaScript("alert('some javascript from server');");
        }

        public ViewResult TestIdGeneration()
        {
            return View();
        }

        [Authorize]
        public ActionResult SecuredView()
        {

            return View();
        }


    }

}

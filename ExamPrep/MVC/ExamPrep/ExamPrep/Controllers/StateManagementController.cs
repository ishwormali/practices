using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPrep.Controllers
{
    public class StateManagementController : Controller
    {
        //
        // GET: /StateManagement/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCookie(string cookieName,string cookieValue)
        {
            HttpCookie cooki = new HttpCookie(cookieName,cookieValue);
            cooki.Expires = DateTime.Now.AddMinutes(2);
            Response.SetCookie(cooki);
            //Response.Cookies.Add(cooki);
            //Response.AppendCookie(cooki);
            return View("Index");
        }
    }
}

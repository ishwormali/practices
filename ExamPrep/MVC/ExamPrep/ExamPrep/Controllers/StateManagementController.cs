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

        //[OutputCache(CacheProfile="")]
        public ActionResult AddCookie(string cookieName, string cookieValue, bool httpOnly)
        {   
            HttpCookie cooki = new HttpCookie(cookieName,cookieValue);
            cooki.Expires = DateTime.Now.AddMinutes(2);
            cooki.HttpOnly = httpOnly;
            Response.SetCookie(cooki);
            
            //Response.Cookies.Add(cooki);
            //Response.AppendCookie(cooki);
            return View("Index");
        }

        public ActionResult StateServer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StateServer(string sessionName,string sessionValue)
        {
            Session[sessionName] = sessionValue;
            return View();
        }
    }
}

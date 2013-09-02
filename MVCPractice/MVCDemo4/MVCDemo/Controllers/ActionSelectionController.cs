using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ActionSelectionController : Controller
    {
        //
        // GET: /ActionSelection/


        /*Example 1
        //[ActionName("SuperIndex")]
        */
        
        public ActionResult Index()
        {
            return View();
        }


        public string MyAction()
        {
            return "MyAction";
        }

        [HttpPost]
        public string MyAction(string temp)
        {
            return "MyAction For Post";
        }

       [ActionName("MyAction")]
        public string NonMyAction()
        {
            return "NonMyAction";
        }

        /* Example 2
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(ActionSelectionClass myobject)
        {
            return View(myobject);
        }

        public class ActionSelectionClass
        {
            public string Field1 { get; set; }

            public string Field2 { get; set; }
        }
        
         */


       /*example 3
       */

       [UserAgentSelector("Firefox")]
        public ActionResult BrowserView(string arbitaryParameter1)
        {
            ViewBag.UserAgent = "Firefox";
            return View();
        }

        [UserAgentSelector("Chrome")]
        public ActionResult BrowserView(string arbitaryParameter1, string arbitaryParameter2)
        {
            ViewBag.UserAgent = "Chrome";
            return View();
        }
        
    }

    
}

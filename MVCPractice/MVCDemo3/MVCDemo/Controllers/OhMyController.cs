using MVCDemo.Models;
using MVCDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
   
    public class OhMyController : Controller
    {
        //
        // GET: /OhMy/
        public IPersonService PersonService{get;set;}

        public ActionResult Index()
        {
            return View();
        }


    }
}

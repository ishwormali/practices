using MVCDemo.Models;
using MVCDemo.Models.DB;
using MVCDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ModelBindingTestController : Controller
    {
        //
        // GET: /ModelBindingTest/


        public ActionResult Index()
        {
           
            return View(new UserInfo());
            
        }

        [HttpPost]
        public ActionResult Save( UserInfo user)// [Bind(Exclude="LastName")]
        {

            if (!ModelState.IsValid)
            {
                return View("Index",user);
            }

            return View(user);

        }

        public ActionResult WithParent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WithParent(UserInfoParent parent)
        {

            return View(parent);

        }
    }
}

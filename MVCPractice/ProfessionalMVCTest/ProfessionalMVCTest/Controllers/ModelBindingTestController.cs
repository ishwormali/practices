using ProfessionalMVCTest.Models;
using ProfessionalMVCTest.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Controllers
{
    public class ModelBindingTestController : Controller
    {
        //
        // GET: /ModelBindingTest/

        public ActionResult Index()
        {
            //UserInfoContext context = new UserInfoContext();
            
            //var users = ee.UserInfoes.ToList();
            //var users = context.UserInfoes.ToList();
            return View(new UserInfo());
            

        }

        [HttpPost]
        public ActionResult Index([ModelBinder(typeof(UserInfoModelBinder))]UserInfo user)
        {
            
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

        [HttpPost]
        public ActionResult SelectedUser(UserInfo user)
        {
            return View(user);
        }

    }
}

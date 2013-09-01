using MVCDemo.Models;
using MVCDemo.Models.DB;
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
            //UserInfoContext context = new UserInfoContext();
            
            //var users = ee.UserInfoes.ToList();
            //var users = context.UserInfoes.ToList();
            return View(UserInfo.Users);
            

        }

        [HttpPost]
        public ActionResult SelectedUser(UserInfo user)
        {
            return View(user);
        }

    }
}

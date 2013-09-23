using ExamPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExamPrep.Controllers
{
    [Authorize]
    public class AuthenticationTestController : Controller
    {
        //
        // GET: /AuthenticationTest/

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
           // if (model.UserName.Equals("adminuser",StringComparison.OrdinalIgnoreCase))
            if(FormsAuthentication.Authenticate(model.UserName,model.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(model.UserName, model.RememberMe);
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("UserName", "User not registered");

            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }



    }
}

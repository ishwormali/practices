using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppSecurityDemo.Models;

namespace WebAppSecurityDemo.Controllers
{
    [Authorize]
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        public ActionResult RestrictedPage()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login,string returnUrl)
        {
            if (Membership.ValidateUser(login.UserName, login.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(login.UserName, login.RememberMe);
                return RedirectToLocal(returnUrl);
            }
            ModelState.AddModelError("UserName", "Invalid User Name");

            return View(login);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
            
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus status;
                var user=Membership.CreateUser(register.UserName, register.Password, register.EmailAddress, register.SecurityQuestion, register.SecurityAnswer, true, out status);
                switch (status)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        break;
                    case MembershipCreateStatus.DuplicateProviderUserKey:
                        break;
                    case MembershipCreateStatus.DuplicateUserName:
                        ModelState.AddModelError("UserName", "Duplicate User Name");
                        break;
                    case MembershipCreateStatus.InvalidAnswer:
                        break;
                    case MembershipCreateStatus.InvalidEmail:
                        break;
                    case MembershipCreateStatus.InvalidPassword:
                        ModelState.AddModelError("Password", "Invalid Password");
                        
                        break;
                    case MembershipCreateStatus.InvalidProviderUserKey:
                        break;
                    case MembershipCreateStatus.InvalidQuestion:
                        break;
                    case MembershipCreateStatus.InvalidUserName:
                        break;
                    case MembershipCreateStatus.ProviderError:
                        break;
                    case MembershipCreateStatus.Success:
                        if (Membership.ValidateUser(register.UserName, register.Password))
                        {
                            FormsAuthentication.RedirectFromLoginPage(register.UserName, false);
                            return RedirectToAction("Index");
                        }
                        return RedirectToAction("Login");

                    case MembershipCreateStatus.UserRejected:
                        break;
                    default:
                        break;
                }

            }

            return View(register);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Authentication");
            }
        }

    }
}

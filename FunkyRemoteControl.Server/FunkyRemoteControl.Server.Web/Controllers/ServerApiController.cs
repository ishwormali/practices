using FunkyRemoteControl.Server.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FunkyRemoteControl.Server.Web.Controllers
{

    public class ServerApiController : ApiController
    {

        public UserManager<ApplicationUser> UserManager { get; set; }

        public ServerApiController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {

        }

        public ServerApiController(UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
        }

        [Route("api/authorize")]
        [HttpPost]
       // [HttpGet]
        public HttpStatusCode Authorize(LoginViewModel login)
        {

            var user = UserManager.FindAsync(login.UserName, login.Password).Result;
            if (user != null)
            {
                SignIn(user,false);
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.NotFound;
            }


        }

        private void SignIn(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie).Result;
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

    }
}

using ProfessionalMVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Controllers
{
    public class CustomBinderController : Controller
    {
        //
        // GET: /CustomBinder/

        public ActionResult Index(
            /*[ModelBinder(typeof(ApplicationSettingModelBinder))]*/
            /*[ApplicationSettingBinder]*/
            ApplicationSetting setting,string otherSetting)
        {
            return View(setting);
        }

    }
}

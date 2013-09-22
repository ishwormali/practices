using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPrep.Controllers
{
    public class GlobalizationController : Controller
    {
        //
        // GET: /Globalization/

        public ActionResult Index(string mylanguage)
        {
            
            if (!string.IsNullOrWhiteSpace(mylanguage))
            {
                var culture = CultureInfo.CreateSpecificCulture(mylanguage);
                if (culture != null)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
                }
            }
            return View();
        }

    }
}

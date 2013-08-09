using ProfessionalMVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Controllers
{
    public class FormsController : Controller
    {
        //
        // GET: /Forms/

        public ActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public ActionResult SimpleType(string myName, string checkboxvalue,string[] checkBoxValueArray)
        {
            return View("Index");
        }

        public ActionResult ComplexType()
        {
            return View("ComplexType");
        }

        [HttpPost]
        public ActionResult ComplexType(FormViewModel myform)
        {
            return View("ComplexType");
        }
    }
}

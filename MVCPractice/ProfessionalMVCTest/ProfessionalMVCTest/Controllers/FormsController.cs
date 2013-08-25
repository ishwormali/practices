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
            var myNameRequestValue = Request["myName"];//Request.Form["myName"];

            return View("Index");
        }

        public ActionResult ComplexType()
        {
            return View("ComplexType");
        }

        [HttpPost]
        public ActionResult ComplexType(FormViewModel myform)
        {
            //FormViewModel newModel=new FormViewModel();
            //if (TryUpdateModel(newModel))
            //{
            //    //is valid model state

            //}
            return View("ComplexType");
        }

        
        public ActionResult Collection()
        {
            var coll = CollectionModel.GetAll();
            return View(coll);
        }

        public ActionResult CollectionSimpleType()
        {
            List<string> coll=new List<string>{"Item A","Item B","Item C","Item D","Item E"};

            return View(coll);
        }

        [HttpPost]
        public ActionResult CollectionSimpleType(List<string> coll)
        {
            return View(coll);
        }

        [HttpPost]
        public ActionResult Collection(CollectionModel[] coll)
        {
            return View(coll);
        }
    }
}

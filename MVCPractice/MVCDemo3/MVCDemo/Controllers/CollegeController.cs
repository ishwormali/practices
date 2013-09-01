using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class CollegeController : Controller
    {
        //
        // GET: /Fruits/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Students(int year, string campus, string extraParam)
        {
            ViewBag.Year = year;
            ViewBag.Campus = campus;
            ViewBag.Group = "New Bloods";
            return View();
        }


        public ActionResult GrandPas(int year, string campus)
        {
            ViewBag.Year = year;
            ViewBag.Campus = campus;
            ViewBag.Group = "GrandPas";
            return View("Students");
        }
        
        
        
        /// <summary>
        /// Simple example
        /// </summary>
        /// <param name="year"></param>
        /// <param name="fruitName"></param>
        /// <returns></returns>
        //public ActionResult History(int year,string fruitName)
        //{
        //    ViewBag.Year = year;
        //    ViewBag.FruitName = fruitName;
        //    return View();
        //}
    }
}

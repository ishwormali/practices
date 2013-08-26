using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo2.Controllers
{
    public class CollegeController : Controller
    {
        //
        // GET: /Fruits/

        public ActionResult Index()
        {
            return View();
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

        public ActionResult Students(int year, string college, string extraParam)
        {
            ViewBag.Year = year;
            ViewBag.College = college;
            ViewBag.Group = "New Bloods";
            return View();
        }


        public ActionResult GrandPas(int year, string college)
        {
            ViewBag.Year = year;
            ViewBag.College = college;
            ViewBag.Group = "GrandPas";
            return View("Students");
        }
    }
}

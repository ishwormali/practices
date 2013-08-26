using MVCDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo2.Controllers
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
        public ActionResult Save(string Id, string Name, int Age, string Address, string IsMarried, string[] Hobbies,string RegistrationDate)
        {

            return View();

        }

        //[HttpPost]
        //public ActionResult SavePerson(Person person)
        //{

        //    return View(person);

        //}

        //[HttpPost]
        //public ActionResult SavePerson()
        //{
        //    Person person = new Person();
        //    if (TryUpdateModel(person))
        //    {
        //        //model is valid
        //    }

        //    return View(person);

        //}


        public ActionResult Fruits()
        {
            string[] fruits = { "Apple", "Orange", "Banana", "Grapes", "Watermelon", "Guava" };
            return View(fruits);

        }

        [HttpPost]
        public ActionResult SaveFruits(string[] fruits)
        {
            return View("Fruits", fruits);
        }

        public ActionResult FruitsList()
        {
            var fruits = new List<Fruit>{new Fruit(){Name="Apple",Price=201,Region="Himalayan"},
                new Fruit{Name="Orange",Price=301,Region="Hilly"},
                new Fruit{Name="Banana",Price=444,Region="Terai"},
                new Fruit{Name="Grapes",Price=324,Region="Terai"},
                new Fruit{Name="Watermelon",Price=667,Region="Hilly"},
                new Fruit{Name="Guava",Price=222,Region="Himalayan"}
            };

            return View(fruits);

        }

        [HttpPost]
        public ActionResult SaveFruitsList(Fruit[] fruits)
        {
            return View("FruitsList", fruits);
        }
    }
}

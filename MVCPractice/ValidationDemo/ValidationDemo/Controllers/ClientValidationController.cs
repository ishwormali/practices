using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationDemo.Models;

namespace ValidationDemo.Controllers
{
    public class ClientValidationController : Controller
    {
        //
        // GET: /ClientValidation/

        public ActionResult Index()
        {
            return View(new Person());

        }

        [HttpPost]
        public ActionResult Index(Person person)
        {
            return View(person);
        }

    }

    public class Person
    {
        [Required(AllowEmptyStrings=false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int Age { get; set; }

        [Required]
        public bool Married { get; set; }

        
        [RequiredIfExp("Married")]
        public string SpouseName { get; set; }
    }
}

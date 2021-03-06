﻿using Ninject;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ControllerActivatorSampleController:Controller
    {

        [Inject]
        public IPersonService PersonService { get; set; }

        public ActionResult Index()
        {
            var people = PersonService.GetAll();
            return View(people);
        }
    }
}
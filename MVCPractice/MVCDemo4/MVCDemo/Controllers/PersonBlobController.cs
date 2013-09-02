using MVCDemo.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class PersonBlobController : Controller
    {
        [Inject]
        public IBlobService BlobService { get; set; }

        public PersonBlobController()//(IBlobService blobService)
        {
            
        }

        public ActionResult Index()
        {
           
            var blobFiles = BlobService.GetFileNames("Personal");
            return View(blobFiles);
        }

    }
}



//
// GET: /BadBlob/


//
//public IBlobService BlobService{get;set;}


//this.BlobService = blobService;
//
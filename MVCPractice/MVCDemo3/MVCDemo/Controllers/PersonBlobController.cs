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
        //
        // GET: /BadBlob/

        public AmazonBlobService BlobService { get; set; }

        //[Inject]
        //public IBlobService BlobService{get;set;}

        public PersonBlobController()//(IBlobService blobService)
        {
            //this.BlobService = blobService;
            BlobService = new AmazonBlobService();
        }

        public ActionResult Index()
        {
            var blobFiles = BlobService.GetFileNames("Personal");
            return View(blobFiles);
        }

    }
}

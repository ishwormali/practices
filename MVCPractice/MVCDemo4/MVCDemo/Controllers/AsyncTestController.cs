using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo2.Controllers
{
    public class AsyncTestController : Controller
    {
        //
        // GET: /AsyncTest/

        public ActionResult Index()
        {
            return View();
        }

        public  async Task<ActionResult> List()
        {
            var service = new AmazonBlobService();
            var files = await service.GetFileNamesAsync("container");

            return View(files);
        }

    }
}

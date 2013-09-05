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

        public Task<ContentResult> Index()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                return Content("good");
            });


        }

        //public ActionResult Index()
        //{

        //    System.Threading.Thread.Sleep(2000);
        //    return Content("good");

        //}

        //public ActionResult List()
        //{
        //    var service = new AmazonBlobService();
        //    var filesTask = service.GetFileNamesAsync("container");
        //    filesTask.Wait();
        //    return View(filesTask.Result);
        //}

        //public ViewResult GetSomething()
        //{
        //    var service = new AmazonBlobService();
        //    var filesTask = service.GetFileNamesAsync("container");

        //    return View("List", filesTask.Result);
            
        //}

        //public  async Task<ActionResult> List()
        //{
        //    var service = new AmazonBlobService();
        //    var files = await service.GetFileNamesAsync("container");
            
        //    return View(files);
        //}

        //public Task<ViewResult> GetSomething()
        //{
        //    var service = new AmazonBlobService();
        //    var filesTask = service.GetFileNamesAsync("container");

        //    return filesTask.ContinueWith((files) =>
        //    {
        //        return View("List",files.Result);
        //    });

        //}

    }
}

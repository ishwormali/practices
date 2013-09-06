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

        //public ActionResult Index()
        //{
        //    var service = new AmazonBlobService();
        //    var files = service.GetFileNames("container");

        //    return View(files);

        //}

        //public Task<ActionResult> Index()
        //{
        //    return Task.Factory.StartNew<ActionResult>(() =>
        //    {
        //        var service = new AmazonBlobService();

        //        var files = service.GetFileNames("container");
        //        return View(files);
        //    });

        //}

        //public Task<ActionResult> Index()
        //{
        //    var tsk = Task.Factory.StartNew(() =>
        //    {
        //        var service = new AmazonBlobService();

        //        var files = service.GetFileNames("container");
        //        return files;
        //    });

        //    return tsk.ContinueWith<ActionResult>((firstTask) =>
        //    {
        //        var service = new AmazonBlobService();
        //        var files = service.GetExtendedFileNames(firstTask.Result);
        //        return View(files.ToList());
        //    });

        //}

        public async Task<ActionResult> Index()
        {
            var service = new AmazonBlobService();
            var files = await service.GetFileNamesAsync("asynccontainer");
            var extendedFiles = await service.GetExtendedFileNamesAsync(files);

            return View(extendedFiles);

        }





























        //public Task<ViewResult> GetSomething()
        //{
        //    var service = new AmazonBlobService();
        //    var filesTask = service.GetFileNamesAsync("container");

        //    return filesTask.ContinueWith((files) =>
        //    {
        //        return View("List",files.Result);
        //    });

        //}

        //public  async Task<ActionResult> List()
        //{
        //    var service = new AmazonBlobService();
        //    var files = await service.GetFileNamesAsync("container");

        //    return View(files);
        //}

        //public ActionResult Index()
        //{

        //    System.Threading.Thread.Sleep(2000);
        //    return Content("good");

        //}

        //public Task<ContentResult> Index()
        //{
        //    return Task.Run(() =>
        //    {
        //        System.Threading.Thread.Sleep(2000);
        //        return Content("good");
        //    });


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

        

       

    }
}

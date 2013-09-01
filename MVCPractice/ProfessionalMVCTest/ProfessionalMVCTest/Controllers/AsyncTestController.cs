using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProfessionalMVCTest.Controllers
{
    public class AsyncTestController : Controller
    {
        //
        // GET: /AsyncTest/

        public ActionResult Index()
        {
            return View();
        }

        public Task LongTask()
        {
            //System.Threading.Thread.Sleep(1000);
            return Task.Run(() => {
                System.Threading.Thread.Sleep(5000);
            });

        }

    }
}

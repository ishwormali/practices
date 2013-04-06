
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
            
        }

        public JsonResult SaveContent(string contentByte)
        {
            
            var byteArr2 =Convert.FromBase64String(contentByte);//convert the base64 string to byte array
            using (var fileStream = System.IO.File.OpenWrite(@"c:\tempfolder\tempfile.docx")) //open a file
            {
                fileStream.Write(byteArr2, 0, byteArr2.Length); //write the byte array as content in the file
            }

            return Json(new { success=true});
            
        }

        

    }
}

using GrabMyContent.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GrabMyContent.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task Grab(GrabRequest request)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(request.Url);
            if (response.IsSuccessStatusCode)
            {
                HandleSuccessResponse(request,response);
            }
            
            HandleFailureResponse(request,response);

        }

        private void HandleSuccessResponse(GrabRequest request,HttpResponseMessage response)
        {
            var contentTypeHeader = response.Headers.FirstOrDefault(m => m.Key == "Content-Type");
            if (contentTypeHeader.Key != null)
            {


                var contentType = contentTypeHeader.Value.FirstOrDefault();
                switch (contentType)
                {
                    case "text/html":
                        HandleTextContent(request,response);
                        break;
                    default:
                        HandleOtherResponse(request, response);
                        break;
                }
            }
            else
            {
                HandleOtherResponse(request, response);
            }

        }

        private void HandleOtherResponse(GrabRequest request, HttpResponseMessage response)
        {
            var path=Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folderName = string.Format("GC{0}", DateTime.Now.Ticks);
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            
            var filePath=string.Format("{0}\\GCFile{1}.css",folderName,DateTime.Now.Ticks);
            Response.ClearContent();
            Response.ClearHeaders();

            using (var fs = System.IO.File.OpenWrite(filePath))
            {
                var buff=response.Content.ReadAsByteArrayAsync().Result;
                fs.Write(buff, 0, buff.Length);
            }

            Response.ContentType = "text/html";
Response.AddHeader("Content-Length", getContent.Length.ToString());
Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
            Response.AddHeader("Content-Disposition","")
        }

        private void HandleTextContent(GrabRequest request,HttpResponseMessage response)
        {
            var responseResult = response.Content.ReadAsByteArrayAsync().Result;
            Response.AppendHeader("Content-Type", "text/html");
            Response.Write(Encoding.UTF8.GetString(responseResult));
            

        }


        private void HandleFailureResponse(GrabRequest request,HttpResponseMessage response)
        {
            
        }
    }
}
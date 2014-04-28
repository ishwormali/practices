using GrabMyContent.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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

        public async Task<ActionResult> Grab(GrabRequest request)
        {
            var webRequest=WebRequest.Create(request.Url);
            using (var response = await webRequest.GetResponseAsync())
            {
                //HttpClient client = new HttpClient();
                //var response = await client.GetAsync(request.Url);
                var statusCode = ((HttpWebResponse)response).StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    return HandleSuccessResponse(request, response);
                }
                else
                {
                    return HandleFailureResponse(request, response);
                }
                
            }

            //var response = await request.GetResponseAsync();
            
            

        }

        private ActionResult HandleSuccessResponse(GrabRequest request, WebResponse response)
        {
            var contentTypeHeader = response.ContentType;
            string contentType = "text/html";
            Encoding encoding = null;
            if (contentTypeHeader != null)
            {
                contentType = contentTypeHeader.Split(';')[0];

                var match = Regex.Match(contentTypeHeader, @"(?<=charset\=).*");
                if (match.Success)
                    encoding = Encoding.GetEncoding(match.ToString());

                
            }

            switch (contentType)
            {
                case "text/html":
                    return HandleTextContent(request, response);
                    break;
                default:
                    return HandleOtherResponse(request, response);
                    break;
            }

            //else
            //{
            //    HandleOtherResponse(request, response);
            //}

        }

        private ActionResult HandleOtherResponse(GrabRequest request, WebResponse response)
        {

            var filePath = GetFilePath();
            //Response.ClearContent();
            //Response.ClearHeaders();

            using (var fs = System.IO.File.OpenWrite(filePath))
            {
                byte[] buffer=new byte[response.ContentLength];
                var buff = response.GetResponseStream().Read(buffer, 0, buffer.Length);

                fs.Write(buffer, 0, buffer.Length);
            }

            return ReturnFile(filePath, request, response);
        }

        private ActionResult HandleTextContent(GrabRequest request, WebResponse response)
        {
            string content = string.Empty;

            using (var reader = new StreamReader(response.GetResponseStream(), ParseEncoding(response)))
            {
                content = reader.ReadToEnd();
            }

            //var responseResult = response.Content.ReadAsByteArrayAsync().Result;
            Response.AppendHeader("Content-Type", "text/html");
            Response.Write(content);
            return new EmptyResult();
        }


        private ActionResult HandleFailureResponse(GrabRequest request,WebResponse response)
        {
            return new EmptyResult();
        }

        private ActionResult ReturnFile(string filePath,GrabRequest request, WebResponse response)
        {
            return File(filePath, "application/msword",string.Format(CultureInfo.InvariantCulture,"{0}.docx",DateTime.Now.ToString()));

        }

        private string GetFilePath()
        {
            var path = GetRootFolder();

            var filePath = string.Format("{0}\\GCFile{1}.docx", path, DateTime.Now.Ticks);
            return filePath;
            
        }

        private string GetRootFolder()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folderName = "GrabMyContent";
            var fullFolderName = Path.Combine(path, folderName);
            if (!Directory.Exists(fullFolderName))
            {
                Directory.CreateDirectory(fullFolderName);
            }

            return fullFolderName;
        }

        private Encoding ParseEncoding(WebResponse response)
        {
            Encoding encoding = null;
            if (response.ContentType != null)
            {
                var match = Regex.Match(response.ContentType, @"(?<=charset\=).*");
                if (match.Success)
                    encoding = Encoding.GetEncoding(match.ToString());
            }
            return encoding;
        }

    }
}
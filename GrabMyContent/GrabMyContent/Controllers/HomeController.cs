using GrabMyContent.Models;
using GrabMyContent.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace GrabMyContent.Controllers
{
    public class HomeController : Controller
    {

        public string Index()
        {
            return "HOME";
        }



        // [RequestKeyValidationActionFilter]
        public ActionResult Grab(GrabRequest request)
        {
            if (request != null && !string.IsNullOrWhiteSpace(request.Url) && !string.IsNullOrWhiteSpace(request.RequestKey))
            {
                var webRequest = WebRequest.Create(request.Url);

                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();

                var response = (HttpWebResponse)webRequest.GetResponse();

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
            }
            else
            {
                return View();
            }


            //var response = await request.GetResponseAsync();

        }

        private ActionResult HandleSuccessResponse(GrabRequest request, HttpWebResponse response)
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

                if (contentType.IndexOf("image") >= 0)
                {
                    contentType = "image";
                }
            }

            switch (contentType)
            {


                case "text/html":
                    return HandleHtmlContent(request, response);
                    break;
                case "image":
                    return HandleBinaryContent(request, response);

                default:
                    return HandleOtherResponse(request, response);
                    break;
            }

            //else
            //{
            //    HandleOtherResponse(request, response);
            //}

        }

        private ActionResult HandleBinaryContent(GrabRequest request, HttpWebResponse response)
        {

            if (string.IsNullOrWhiteSpace(request.ToEmail))
            {
                return new HttpWebResponseResult(response);
                //byte[] buffer = new byte[response.ContentLength];
                //var buff = response.GetResponseStream().Read(buffer, 0, buffer.Length);
                //Response.OutputStream.Write(buffer, 0, buffer.Length);
                var contentType = response.ContentType;
                //Response.AppendHeader("Content-Type", contentType);
                return new FileStreamResult(response.GetResponseStream(), contentType);

            }
            else
            {
                return HandleOtherResponse(request, response);
            }

            return new EmptyResult();
        }

        private ActionResult HandleOtherResponse(GrabRequest request, HttpWebResponse response)
        {

            var filePath = GetFilePath();
            //Response.ClearContent();
            //Response.ClearHeaders();

            using (var fs = System.IO.File.OpenWrite(filePath))
            {
                byte[] buffer = new byte[response.ContentLength];
                //var buff = response.GetResponseStream().Read(buffer, 0, buffer.Length);
                var responseStrm = response.GetResponseStream();
                var buff = 0;
                while ((buff = responseStrm.ReadByte()) >= 0)
                {
                    fs.WriteByte(Convert.ToByte(buff));
                }

            }

            return ReturnFile(filePath, request, response);
        }

        private ActionResult HandleHtmlContent(GrabRequest request, HttpWebResponse response)
        {
            return new HttpWebResponseResult(response);
        }


        private ActionResult HandleFailureResponse(GrabRequest request, HttpWebResponse response)
        {
            return new EmptyResult();
        }

        private ActionResult ReturnFile(string filePath, GrabRequest request, HttpWebResponse response)
        {
            try
            {

                var message = new MailMessage();
                message.To.Add(request.ToEmail);

                message.Attachments.Add(new Attachment(filePath));
                message.Body = string.Format(CultureInfo.InvariantCulture, "Here is your content for the following parameters : {0}", this.HttpContext.Request.Url.Query);

                var client = new SmtpClient();

                client.EnableSsl = false;

                client.Send(message);

                return new ContentResult() { Content = "Successful operation" };
            }
            catch (Exception ex)
            {
                return new ContentResult() { Content = ex.Message };
                //throw;
            }

            //return File(filePath, "application/msword",string.Format(CultureInfo.InvariantCulture,"{0}.docx",DateTime.Now.ToString()));

        }

        private string GetFilePath()
        {
            var path = GetRootFolder();

            var filePath = string.Format("{0}\\GCFile{1}.docx", path, DateTime.Now.Ticks);
            return filePath;

        }

        private string GetRootFolder()
        {
            var path = Server.MapPath("~/temp");
            var folderName = "GrabMyContent";
            var fullFolderName = Path.Combine(path, folderName);
            if (!Directory.Exists(fullFolderName))
            {
                Directory.CreateDirectory(fullFolderName);
            }

            return fullFolderName;
        }

        private Encoding ParseEncoding(HttpWebResponse response)
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

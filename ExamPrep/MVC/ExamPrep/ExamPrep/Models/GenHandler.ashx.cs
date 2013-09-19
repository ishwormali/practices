using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    /// <summary>
    /// Summary description for GenHandler
    /// </summary>
    public class GenHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World from generic handler");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
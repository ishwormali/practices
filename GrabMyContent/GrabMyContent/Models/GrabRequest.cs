using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrabMyContent.Web.Models
{
    public class GrabRequest
    {
        public string Url { get; set; }
        public string ToEmail { get; set; }
    }
}
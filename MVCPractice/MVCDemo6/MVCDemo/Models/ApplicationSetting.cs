using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class ApplicationSetting
    {

        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string ReleasedDate { get; set; }
        public bool IsOffline { get; set; }
    }
}
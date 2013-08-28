using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class NameFormatter:INameFormatter
    {
        public string FormatName(string containerPath, string fileName)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} - {1}", containerPath, fileName);
        }
    }

    public interface INameFormatter
    {
        string FormatName(string containerPath, string fileName);
    }
}
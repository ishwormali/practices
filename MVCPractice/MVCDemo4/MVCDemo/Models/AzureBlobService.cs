using MVCDemo.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo2.Models
{
    public class AzureBlobService : IBlobService
    {
        //[Inject]
        public NameFormatter Formatter { get; set; }

        public AzureBlobService()
        {
            Formatter = new NameFormatter();

        }

        public IList<string> GetFileNames(string containerPath)
        {
            return new List<string>{
                Formatter.FormatName(containerPath,"File 1"),
                Formatter.FormatName(containerPath,"File 2"),
                Formatter.FormatName(containerPath,"File 3"),
                Formatter.FormatName(containerPath,"File 4")
            };
        }
    }
}
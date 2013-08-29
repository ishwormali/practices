using Ninject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class AmazonBlobService : IBlobService
    {

        public IList<string> GetFileNames(string containerPath)
        {
            //do some amazon web service calls.
            return new List<string>{
                string.Format("{0} - {1} ",containerPath,"File 1"),
                string.Format("{0} - {1} ",containerPath,"File 2"),
                string.Format("{0} - {1} ",containerPath,"File 3"),
                string.Format("{0} - {1} ",containerPath,"File 4")
            };
            
        }
    }

    
}




using Ninject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCDemo.Models
{
    public class AmazonBlobService
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

        public Task<IList<string>> GetFileNamesAsync(string containerPath)
        {
            return Task.Factory.StartNew<IList<string>>(() =>
            {
                Task.Delay(5000);
                return new List<string>{
                        string.Format("{0} - {1} ",containerPath,"File 1"),
                        string.Format("{0} - {1} ",containerPath,"File 2"),
                        string.Format("{0} - {1} ",containerPath,"File 3"),
                        string.Format("{0} - {1} ",containerPath,"File 4")
                    };
            });
        }

        public Task<IList<string>> GetFolderNamesAsync()
        {
            
            return Task.Factory.StartNew<IList<string>>(() =>
            {
                Task.Delay(5000);
                return new List<string>{
                        string.Format("{0} ","Folder 1"),
                        string.Format("{0} ","Folder 2"),
                        string.Format("{0} ","Folder 3")

                    };
            });
        }

        
    }

    
}



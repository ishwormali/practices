using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RemoteControlClient
{
    public class RemoteController:ApiController
    {

        public void Get(string command,string parameters)
        {
            Console.WriteLine(string.Format("Command : {0}, Parameters : {1} ", command, parameters));
            if ("executecommand".Equals(command, StringComparison.OrdinalIgnoreCase))
            {
                System.Diagnostics.Process.Start("CMD.exe","/C " + parameters);
            }
        }
    }
}

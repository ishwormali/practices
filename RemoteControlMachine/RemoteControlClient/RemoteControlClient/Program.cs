using Microsoft.AspNet.SignalR.Client;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

 

namespace RemoteControlClient
{
    
    class Program
    {
        private static WebBrowser browser;

        //[STAThread]
        static void Main(string[] args)
        {
            HubConnection hub = new HubConnection("http://localhost:57365/");
            
            var prxy=hub.CreateHubProxy("RemoteHub");
            prxy.On<string, string>("commandReceived", (command, parameters) => {
                Console.WriteLine(string.Format("Command : {0}, Parameters : {1} ", command, parameters));
                if ("executecommand".Equals(command, StringComparison.OrdinalIgnoreCase))
                {
                    System.Diagnostics.Process.Start("CMD.exe", "/C " + parameters);
                }
            });
            hub.Start().Wait();

            //var config = new HttpSelfHostConfiguration("http://localhost:4521");
            //System.Threading.Thread.Sleep(5000);
            //config.Routes.MapHttpRoute(
            //    "API Default", "api/{controller}/{id}",
            //    new { id = RouteParameter.Optional });

            //using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            //{
            //    server.OpenAsync().Wait();
            //    Console.WriteLine("Press Enter to quit.");
            //    Console.ReadLine();
            //}
            Console.ReadLine();
        }

    }
}

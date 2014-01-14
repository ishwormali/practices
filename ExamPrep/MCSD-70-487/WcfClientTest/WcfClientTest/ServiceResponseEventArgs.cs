using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfClientTest
{
    public delegate void ServiceResponseEventHandler(object sender, ServiceResponseEventArgs e);

    public class ServiceResponseEventArgs:EventArgs
    {
        public object Response { get; set; }
    }
}

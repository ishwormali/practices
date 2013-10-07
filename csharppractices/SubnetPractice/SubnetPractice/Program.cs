using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SubnetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress addr = IPAddress.Parse("192.168.0.0");
            var subnetMaskWithSlash = "10.0.0.0/16";
            var bits = subnetMaskWithSlash.Substring(subnetMaskWithSlash.IndexOf("/")+1, subnetMaskWithSlash.Length-subnetMaskWithSlash.IndexOf("/")-1);
            Console.WriteLine(bits);
            var temp=System.Net.IPAddress.Parse(subnetMaskWithSlash);
            Console.ReadLine();
        }
    }
}

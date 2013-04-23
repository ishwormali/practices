using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace UACTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckCurrentUserRole();    
            Console.Read();
        }
        
        static void CheckCurrentUserRole()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principle = new WindowsPrincipal(identity);

            var isAdmin = principle.IsInRole(WindowsBuiltInRole.Administrator);

            Console.WriteLine((isAdmin?"Current User is in Admin group":"Current User is not in Admin group."));
        }

        static void WriteEventLog()
        {
            var source = "MYAPP";
            if (!EventLog.SourceExists(source))
            {

                Console.WriteLine("source doesnt exist");

                EventLog.CreateEventSource(source, "Application");

            }
            else
            {
                Console.WriteLine("source exist");
                EventLog.DeleteEventSource(source);
                Console.WriteLine("source removed");
                EventLog.CreateEventSource(source, "Application");

            }

            EventLog.WriteEntry(source, "some message at:" + DateTime.Now.ToString(CultureInfo.InvariantCulture), EventLogEntryType.Information);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ProfessionalMVCTest.App_Start.AppStartup), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(ProfessionalMVCTest.App_Start.AppStartup), "Stop")]

namespace ProfessionalMVCTest.App_Start
{
    public static class AppStartup
    {
        public static void Start()
        {

        }

        public static void Stop()
        {

        }
    }
}
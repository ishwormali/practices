using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.ServiceModel;
using System.Text;

namespace WcfServiceTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SecureService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SecureService.svc or SecureService.svc.cs at the Solution Explorer and start debugging.
    public class SecureService : ISecureService
    {
        
        public string GetSecureString(string anyMessage)
        {
            return Guid.NewGuid().ToString();
        }
    }
}

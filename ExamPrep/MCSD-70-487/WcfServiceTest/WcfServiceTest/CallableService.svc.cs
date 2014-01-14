using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CallableService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CallableService.svc or CallableService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class CallableService : ICallableService
    {
        private ICallableServiceCallback callback;
        public CallableService()
        {
            callback = OperationContext.Current.GetCallbackChannel<ICallableServiceCallback>();
        }

        public void Add(double i, double j)
        {
            if (callback != null)
            {
                callback.Respond(i + j);
            }
        }


        public void GenerateTime()
        {
            if (callback != null)
            {
                callback.Respond(DateTime.Now);
            }
        }
    }
}

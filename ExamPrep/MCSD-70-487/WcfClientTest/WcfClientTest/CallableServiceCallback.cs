using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfClientTest.ServiceReference1;

namespace WcfClientTest
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CallableServiceCallback : ICallableServiceCallback
    {
        public event ServiceResponseEventHandler ServiceResponse;

        public void Respond(object response)
        {
            if (ServiceResponse != null)
            {
                ServiceResponse(this, new ServiceResponseEventArgs() { Response = response });
            }
        }
    }
}

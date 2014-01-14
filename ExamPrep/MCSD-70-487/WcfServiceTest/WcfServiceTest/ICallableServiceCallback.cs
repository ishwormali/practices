using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WcfServiceTest
{

    public interface ICallableServiceCallback
    {
        [OperationContract(IsOneWay=true)]
        void Respond(object response);
    }
}
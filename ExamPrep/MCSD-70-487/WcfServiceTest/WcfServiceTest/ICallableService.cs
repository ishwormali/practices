using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICallableService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(ICallableServiceCallback), SessionMode = SessionMode.Required)]
    public interface ICallableService
    {
        [OperationContract(IsOneWay=true)]
        void Add(double i, double j);

        [OperationContract(IsOneWay = true)]
        void GenerateTime();
    }
}

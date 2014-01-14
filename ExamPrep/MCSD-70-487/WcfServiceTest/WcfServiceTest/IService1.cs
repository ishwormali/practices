using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Security;

namespace WcfServiceTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [MessageContract(WrapperNamespace="www.example.com/contract",WrapperName="WrappedCompositeType",IsWrapped=false)]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [MessageHeader(Name = "HeaderBool", Namespace = "www.example.com/header")]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [MessageBodyMember(Name="StringBody",Namespace="www.example.com/body")]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}

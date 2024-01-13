using CoreWCF;
using System;
using System.Runtime.Serialization;

namespace EccGw
{
    [ServiceContract(Namespace = "http://saga.rs/ncts/services")]
    public interface IGatewayService
    {
        [OperationContract]
        string Deliver(string envelope);

        [OperationContract]
        string Confirm(string envelope);

        [OperationContract]
        string Send(string envelope);

        [OperationContract]
        string Pool(string communicationAuthorizationId, string communicationDomain, string password);

        [OperationContract(Name = "PoolPWC")]
        string PoolPwc(string communicationAuthorizationId, string communicationDomain, string password);
    }


    public class GatewayService : IGatewayService
    {
        public string Confirm(string envelope)
        {
            throw new NotImplementedException();
        }

        public string Deliver(string envelope)
        {
            return envelope;
        }

        public string Pool(string communicationAuthorizationId, string communicationDomain, string password)
        {
            return $"{communicationAuthorizationId}:{communicationDomain}: {password}";
        }

        public string PoolPwc(string communicationAuthorizationId, string communicationDomain, string password)
        {
            return string.Join(":", new List<string> { communicationAuthorizationId, communicationDomain, password });
        }

        public string Send(string envelope)
        {
            return envelope;
        }
    }
}
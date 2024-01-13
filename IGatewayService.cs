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


    public class GatewayService(ILogger<GatewayService> log) : IGatewayService
    {
        public string Confirm(string envelope)
        {
            log.LogInformation("Method Confirm with envelope: {envelope}", envelope);
            return envelope;
        }

        public string Deliver(string envelope)
        {
            log.LogInformation("Method Deliver with envelope: {envelope}", envelope);
            return envelope;
        }

        public string Pool(string communicationAuthorizationId, string communicationDomain, string password)
        {
            log.LogInformation(
                "Method Pool with communicationAuthorizationId: {authId}, communicationDomain: {commDomain}, password: {pass}",
                communicationAuthorizationId, communicationDomain, password);
            return $"{communicationAuthorizationId}:{communicationDomain}: {password}";
        }

        public string PoolPwc(string communicationAuthorizationId, string communicationDomain, string password)
        {
            log.LogInformation(
                "Method PoolPWC with communicationAuthorizationId: {authId}, communicationDomain: {commDomain}, password: {pass}",
                communicationAuthorizationId, communicationDomain, password);
            return $"{communicationAuthorizationId}:{communicationDomain}: {password}";
        }

        public string Send(string envelope)
        {
            log.LogInformation("Method Send with envelope: {envelope}", envelope);
            return envelope;
        }
    }
}
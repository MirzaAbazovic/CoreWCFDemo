using System.Reflection;
using System.Text;

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

    public partial class GatewayService(ILogger<GatewayService> log) : IGatewayService
    {
        public string Confirm(string envelope,
            [Injected] HttpRequest req, [Injected] HttpResponse res)
        {
            LogMethodCall(MethodBase.GetCurrentMethod(), envelope, req, res);
            return envelope;
        }

        public string Deliver(string envelope,
            [Injected] HttpRequest req, [Injected] HttpResponse res)
        {
            LogMethodCall(MethodBase.GetCurrentMethod(), envelope, req, res);
            return envelope;
        }

        public string Pool(string communicationAuthorizationId, string communicationDomain, string password,
            [Injected] HttpRequest req, [Injected] HttpResponse res)
        {
            var payload = $"{communicationAuthorizationId}:{communicationDomain}:{password}";
            LogMethodCall(MethodBase.GetCurrentMethod(), payload, req, res);
            return payload;
        }

        public string PoolPwc(string communicationAuthorizationId, string communicationDomain, string password,
            [Injected] HttpRequest req, [Injected] HttpResponse res)
        {
            var payload = $"{communicationAuthorizationId}:{communicationDomain}:{password}";
            LogMethodCall(MethodBase.GetCurrentMethod(), payload, req, res);
            return payload;
        }

        public string Send(string envelope,
            [Injected] HttpRequest req, [Injected] HttpResponse res)
        {
            LogMethodCall(MethodBase.GetCurrentMethod(), envelope, req, res);
            return envelope;
        }

        private void LogMethodCall(MethodBase? method, string payload, HttpRequest req, HttpResponse res)
        {
            var headersSb = new StringBuilder();
            foreach (var (key, value) in req.Headers)
            {
                headersSb.AppendLine($"{key}:{value}");
            }

            log.LogInformation(
                $"Called method {method!.Name} with payload: {payload}\n" +
                $"Request headers: {headersSb}, " +
                $"Response status code {res.StatusCode}");
        }
    }
}
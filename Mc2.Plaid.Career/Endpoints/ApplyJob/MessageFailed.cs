using Newtonsoft.Json;

namespace Mc2.Plaid.Career.Endpoints.ApplyJob
{
    public class MessageFailed : IFailedResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

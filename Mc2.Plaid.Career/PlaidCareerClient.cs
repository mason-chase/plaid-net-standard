using Azihub.Utilities.Base.Extensions.Object;
using Mc2.Plaid.Career.Endpoints;
using Mc2.Plaid.Career.Exceptions;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace Mc2.Plaid.Career
{
    public partial class PlaidCareerClient : IEndpoints
    {
        private const string BASE_URL = "https://contact.plaid.com";
        private static Uri BaseUrl => new Uri(BASE_URL);
        public PlaidCareerClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = BaseUrl
            };
        }
        private readonly HttpClient _httpClient;
        
        private Response<TSuccess, TFailed> SendApiRequest<TSuccess, TFailed>(HttpMethod method, object requestParams, string endpoint, SelectCase selectCase = SelectCase.PascalToSnakeCase)
        {
            HttpRequestMessage requestMessage;
            if (method == HttpMethod.Get)
            {
                string queryParams = requestParams.GetQueryString(selectCase);
                requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{endpoint}?{queryParams}");
            }
            else if (method == HttpMethod.Post)
            {

                requestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint);
                string postData = JsonConvert.SerializeObject(requestParams);
                StringContent requestContent = new StringContent(postData, Encoding.UTF8, "application/json");
                requestMessage.Content = requestContent;

            }
            else
                throw new InvalidOperationException("Unsupported HttpMethod: "+method);

            HttpResponseMessage responseMessage;
            string body;
            try
            {
                responseMessage = _httpClient.SendAsync(requestMessage)
                                                           .GetAwaiter()
                                                           .GetResult();

                body = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            }
            catch(Exception ex)
            {
                throw new NetworkLayerException("Failed to connect to server", ex);
            }

            try
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    TSuccess responseBody = JsonConvert.DeserializeObject<TSuccess>(body);
                    return Response<TSuccess, TFailed>.MakeSuccess(responseBody);

                }
            }
            catch (JsonSerializationException ex)
            {
#if DEBUG
                Debugger.Log(1, "Error", ex.Message);
                Debugger.Break();
#else
                
#endif
                try
                {
                    TFailed responseBody = JsonConvert.DeserializeObject<TFailed>(body);
                    return Response<TSuccess, TFailed>.MakeFailed(responseBody);
                }
                catch(JsonSerializationException)
                {
                    throw new BadServerResponseException(responseMessage, body);
                }
            }
            throw new Exception("Unhandled Exceptions");
        }

    }
}

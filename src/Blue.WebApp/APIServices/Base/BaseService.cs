using Blue.WebApp.APIServices.APIRequests;
using Blue.WebApp.Extensions;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Blue.WebApp.APIServices.Base {
    public class BaseService : IBaseService {
        private readonly IHttpClientFactory httpClient;

        public void Dispose() {
            GC.SuppressFinalize(true);
        }

        public BaseService(IHttpClientFactory httpClientFactory) {
            httpClient = httpClientFactory;
        }

        public async Task<T> SendAync<T>(APIRequest request) {
            try {
                var msgRequest = new HttpRequestMessage(request.Method, request.Url);

                if (request.Data != null) {
                    msgRequest.Content = new StringContent(JsonConvert.SerializeObject(request.Data));
                    msgRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }

                var client = httpClient.CreateClient(request.HttpClient);
                var response = await client.SendAsync(msgRequest, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false);
                return await response.ReadContentAs<T>();
            }
            catch {
                return default;
            }
        }
    }
}

using CopaFilmes.Web.Http.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmes.Web.Http
{
    public class ApiOperations : IApiOperations
    {
        public ResponseOperation Get(string endpoint)
            => Get(endpoint, null);

        public ResponseOperation Get(string endpoint, IDictionary<string, string> headers)
            => GetAsync(endpoint, headers).Result;

        public async Task<ResponseOperation> GetAsync(string endpoint)
            => await GetAsync(endpoint, null);

        public async Task<ResponseOperation> GetAsync(string endpoint, IDictionary<string, string> headers)
            => await DoOperationAsync(RequestType.Get, endpoint, headers);

        private async static Task<ResponseOperation> DoOperationAsync(RequestType requestType, string endpoint,
            IDictionary<string, string> headers = null, dynamic request = null)
        {
            using (var client = new HttpClient())
            {
                var requestBody = request != null ? JsonConvert.SerializeObject(request) : null;
                try
                {
                    client.BaseAddress = new Uri(endpoint);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (headers != null)
                        foreach (var header in headers)
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);

                    var response = await DoRequestAsync(requestType, client, request);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return new ResponseOperation(requestBody, responseBody, endpoint, response.StatusCode);
                }
                catch (Exception ex)
                {
                    return new ResponseOperation(endpoint, requestBody, ex);
                }
            }
        }

        private static StringContent BuildContent(dynamic request)
        {
            var content = default(StringContent);
            var contentBody = JsonConvert.SerializeObject(request);

            if (request != null)
                content = new StringContent(contentBody, Encoding.UTF8, "application/json");

            return content;
        }

        private static async Task<HttpResponseMessage> DoRequestAsync(RequestType requestType, HttpClient client, dynamic request)
        {
            var response = default(HttpResponseMessage);
            var content = BuildContent(request);

            switch (requestType)
            {
                case RequestType.Get:
                    response = await client.GetAsync(string.Empty);
                    break;
                case RequestType.Post:
                    response = await client.PostAsync(string.Empty, content);
                    break;
                case RequestType.Put:
                    response = await client.PutAsync(string.Empty, content);
                    break;
                case RequestType.Del:
                    response = await client.DeleteAsync(string.Empty);
                    break;
                default:
                    break;
            }

            return response;
        }
    }
}
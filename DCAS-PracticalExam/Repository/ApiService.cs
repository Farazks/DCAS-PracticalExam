using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Repository
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public ApiService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            using HttpClient client = new();
            SetRequestHeaders(client);

            var response = await client.PostAsJsonAsync(endpoint, data);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error: {response.StatusCode} - {error}");
            }

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        void SetRequestHeaders(HttpClient client)
        {
            client.BaseAddress = new Uri(_config["APIBaseUrl"]);

#if (DEBUG)
            client.Timeout = TimeSpan.FromMinutes(10);
#else
                    string httpRequestExpire = _config["HttpReqExpireTime"] ?? "5";

                    client.Timeout = TimeSpan.FromMinutes(Convert.ToInt16(httpRequestExpire));
#endif
          
            client.DefaultRequestHeaders.Add("x-Gateway-APIKey", _config["ApiKeyValue"]);

        }
    }
}

using ProductManagementAPI.Infrastructure.Interfaces;
using System.Text.Json;

namespace ProductManagementAPI.Infrastructure.HttpClients
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;

        public ApiClient(HttpClient httpClient, JsonSerializerOptions serializerOptions)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _serializerOptions = serializerOptions ?? throw new ArgumentNullException(nameof(serializerOptions));
        }

        public async Task<T?> GetAsync<T>(string url) where T : class
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                
                throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(content))
            {
               
                return default;
            }

            try
            {
                return JsonSerializer.Deserialize<T>(content, _serializerOptions);
            }
            catch (JsonException)
            { 
                throw;
            }
        }
 
    }
}

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
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL cannot be null or whitespace.", nameof(url));
            }

            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                // Consider logging the error or handling different status codes appropriately
                throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return DeserializeContent<T>(content);
        }

        private T? DeserializeContent<T>(string content) where T : class
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return default;
            }

            try
            {
                return JsonSerializer.Deserialize<T>(content, _serializerOptions);
            }
            catch (JsonException ex)
            {
                // Consider logging the exception or handling it if necessary
                throw new InvalidOperationException("Error deserializing the response content.", ex);
            }
        }
    }
}

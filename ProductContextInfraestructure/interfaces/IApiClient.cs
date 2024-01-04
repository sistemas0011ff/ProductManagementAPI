using System;
using System.Threading.Tasks;

namespace ProductManagementAPI.Infrastructure.Interfaces
{
    public interface IApiClient
    {
        /// <summary>
        /// Sends a GET request to the specified URL and returns the response body deserialized as a type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize the response body into. Must be a reference type.</typeparam>
        /// <param name="url">The URL the request is sent to.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized response body as type <typeparamref name="T"/>, or null if the response body is empty.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided <paramref name="url"/> is null.</exception>
        /// <exception cref="HttpRequestException">Thrown if the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation, or timeout.</exception>
        /// <exception cref="JsonException">Thrown if the response body cannot be deserialized into type <typeparamref name="T"/>.</exception>
        Task<T?> GetAsync<T>(string url) where T : class;
         
    }
}

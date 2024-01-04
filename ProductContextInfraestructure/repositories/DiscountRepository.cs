using ProductManagementAPI.Infrastructure.Interfaces;
using ProductManagementAPI.Product.Domain.interfaces;
using ProductManagementAPI.Product.Domain.dto;

namespace ProductManagementAPI.Infrastructure.repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IApiClient _apiClient; 

        public DiscountRepository(IApiClient apiClient, string discountEndpoint)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));    
        }

        public async Task<DiscountDto> GetDiscountForProductAsync(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException("Product ID cannot be null or whitespace.", nameof(productId));
            }

            try
            {
                var discount = await _apiClient.GetAsync<DiscountDto>($"{"discounts"}/{productId}");
                return discount ?? throw new InvalidOperationException($"Discount for product ID '{productId}' not found.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while fetching discount for product ID '{productId}'.", ex);
            }
        }


    }
}

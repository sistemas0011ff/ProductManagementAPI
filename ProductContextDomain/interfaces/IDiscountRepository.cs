using ProductManagementAPI.Product.Domain.dto;

namespace ProductManagementAPI.Product.Domain.interfaces
{
    public interface IDiscountRepository
    {
        Task<DiscountDto> GetDiscountForProductAsync(string productId);
    }
}

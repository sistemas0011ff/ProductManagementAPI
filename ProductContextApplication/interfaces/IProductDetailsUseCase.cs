using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.interfaces
{
    public interface IProductDetailsUseCase
    {
        Task<ProductApplicationDto> GetByIdAsync(string productId);
    }
}

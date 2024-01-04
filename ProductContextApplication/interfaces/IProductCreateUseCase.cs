

using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.interfaces
{
    public interface IProductCreateUseCase
    {
        Task<ProductResponseApplicationDto> CreateProductAsync(ProductRequestApplicationDto request);
    }
}

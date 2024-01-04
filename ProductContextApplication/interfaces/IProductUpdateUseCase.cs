using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.interfaces
{
    public interface IProductUpdateUseCase
    {
        Task<UpdateProductResponseDto> UpdateProductAsync(ProductUpdateApplicationDto request);
    }
}

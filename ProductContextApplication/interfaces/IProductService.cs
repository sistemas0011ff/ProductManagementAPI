using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.interfaces
{
    public interface IProductService
    {
        Task<ProductApplicationDto> CreateProductAsync(ProductApplicationDto productDto);
        Task<ProductApplicationDto> GetProductByIdAsync(string id);
        Task<UpdateProductResponseDto> UpdateProductAsync(ProductUpdateApplicationDto productUpdateDto); // Nuevo método
    }
}

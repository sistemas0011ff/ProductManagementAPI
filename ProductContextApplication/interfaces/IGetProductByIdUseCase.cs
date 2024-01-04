using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.interfaces
{
    public interface IGetProductByIdUseCase
    {
        Task<ProductApplicationDto> ExecuteAsync(string productId);
    }
}

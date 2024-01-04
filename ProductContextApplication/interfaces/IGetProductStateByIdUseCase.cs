using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.interfaces
{
    public interface IGetProductStateByIdUseCase
    {
        Task<ProductStateDto> ExecuteAsync(int stateId);
    }
}

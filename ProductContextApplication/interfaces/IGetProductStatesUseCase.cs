using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.interfaces
{
    public interface IGetProductStatesUseCase
    {
        Task<IEnumerable<ProductStateDto>> ExecuteAsync();
    }
}

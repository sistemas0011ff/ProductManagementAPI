using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.interfaces
{
    public interface IProductStateService
    {
        Task<IEnumerable<ProductStateDto>> LoadStatesAsync();
    }
}

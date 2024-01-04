
using ProductManagementAPI.Product.Domain.dto;

namespace ProductManagementAPI.Product.Domain.interfaces
{
    public interface IProductStateRepository
    {
        Task<IEnumerable<ProductStateInfrastructureDto>> GetProductStatesAsync();
    }
}

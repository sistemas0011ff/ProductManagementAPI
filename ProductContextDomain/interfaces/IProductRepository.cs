using ProductManagementAPI.Product.Domain.dto;

namespace ProductManagementAPI.Product.Domain.interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(ProductInfrastructureDto product);
        Task<IEnumerable<ProductInfrastructureDto>> GetAllAsync();
        Task<ProductInfrastructureDto> GetByIdAsync(string productId);
        Task UpdateAsync(ProductInfrastructureDto product);
        Task DeleteAsync(string productId);
    }
}

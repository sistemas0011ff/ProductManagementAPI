using ProductManagementAPI.Product.Domain.dto;
namespace ProductManagementAPI.Product.Domain.interfaces
{
    public interface IProductFactory
    {
        ProductManagementAPI.Product.Domain.aggregates.Product CreateProduct(ProductCreationDto productCreationDto);
    }
}

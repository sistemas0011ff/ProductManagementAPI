using ProductManagementAPI.Product.Domain.dto;
using ProductManagementAPI.Product.Domain.interfaces;
using ProductManagementAPI.Product.Domain.valueObjects;

namespace ProductManagementAPI.Product.Domain.factory
{
    public class ProductFactory : IProductFactory
    {
        private readonly IProductIdentityService _identityService;

        public ProductFactory(IProductIdentityService identityService)
        {
            _identityService = identityService;
        }

        public ProductManagementAPI.Product.Domain.aggregates.Product CreateProduct(ProductCreationDto productCreationDto)
        {
            var productId = _identityService.GenerateUniqueId();
            var productStatus = new ProductStatus(productCreationDto.Status);
            var productIdValue = new ProductId(productId);
            return new ProductManagementAPI.Product.Domain.aggregates.Product(
                productIdValue,
                productCreationDto.Name,
                productCreationDto.Price,
                productCreationDto.Stock,
                productCreationDto.Description,
                productStatus
            );
        }
    }
}

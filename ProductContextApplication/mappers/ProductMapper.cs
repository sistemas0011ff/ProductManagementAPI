using ProductManagementAPI.Product.Application.dto; 

namespace ProductManagementAPI.Product.Application.mappers
{
    public static class ProductMapper
    {
        public static ProductRequestApplicationDto MapToProductRequest(ProductApplicationDto dto)
        {
            return new ProductRequestApplicationDto
            {
                Name = dto.Name,
                Status = dto.Status,
                Stock = dto.Stock,
                Description = dto.Description,
                Price = dto.Price
            };
        }

        public static ProductApplicationDto ToApplicationDto(ProductManagementAPI.Product.Domain.aggregates.Product product)
        {
            return new ProductApplicationDto
            {
                ProductId = product.ProductId.Value,
                Name = product.Name,
                Status = product.Status.Value,
                Stock = product.Stock,
                Description = product.Description,
                Price = product.Price
            };
        }

        
    }
}

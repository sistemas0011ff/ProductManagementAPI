using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Domain.entities;
using ProductManagementAPI.Product.Domain.valueObjects;

namespace ProductManagementAPI.Product.Application.mappers
{
    public static class GetProductByIdMapper
    {
        public static Product.Domain.aggregates.Product MapToDomainEntity(ProductApplicationDto productDto)
        {
            if (productDto == null)
                throw new ArgumentNullException(nameof(productDto));

            return new Product.Domain.aggregates.Product(
                new ProductId(productDto.ProductId),
                productDto.Name,
                productDto.Price,
                productDto.Stock,
                productDto.Description,
                new ProductStatus(productDto.Status)
            );
        }

        public static ProductApplicationDto MapToApplicationDto(
            Product.Domain.aggregates.Product product,
            ProductStateDto statusDto,
            DiscountApplicationDto discountDto)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (statusDto == null)
                throw new ArgumentNullException(nameof(statusDto));
            if (discountDto == null)
                throw new ArgumentNullException(nameof(discountDto));

            product.ApplyDiscount(new Discount(discountDto.DiscountPercent));
            var finalPrice = product.CalculateFinalPrice();

            return new ProductApplicationDto
            {
                ProductId = product.ProductId.ToString(),
                Name = product.Name,
                Status = product.Status.Value,
                StatusName = statusDto.Name,
                Stock = product.Stock,
                Description = product.Description,
                Price = product.Price,
                Discount = discountDto.DiscountPercent,
                FinalPrice = finalPrice
            };
        }
    }
}

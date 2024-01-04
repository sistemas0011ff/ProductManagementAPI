using MediatR;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Domain.valueObjects;

namespace ProductManagementAPI.Product.Application.queries
{
    public class GetProductDiscountQuery : IRequest<DiscountApplicationDto>
    {
        public ProductId ProductId { get; }

        public GetProductDiscountQuery(ProductId productId)
        {
            ProductId = productId;
        }
    }
}

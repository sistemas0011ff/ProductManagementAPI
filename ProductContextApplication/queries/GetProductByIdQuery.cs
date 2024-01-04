using MediatR;
using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.queries
{
    public class GetProductByIdQuery : IRequest<ProductApplicationDto>
    {
        public string ProductId { get; private set; }

        public GetProductByIdQuery(string productId)
        {
            ProductId = productId;
        }
    }
}

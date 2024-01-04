using MediatR;
using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.queries
{
    public class GetProductStateByIdQuery : IRequest<ProductStateDto>
    {
        public int? StateId { get; set; }
    }
}

using MediatR;
using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.queries
{
    public class GetProductStatesQuery : IRequest<IEnumerable<ProductStateDto>>
    {
    }
}

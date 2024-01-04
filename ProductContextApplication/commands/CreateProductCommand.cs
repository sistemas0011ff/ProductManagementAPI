using MediatR;
using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.commands
{
    public class CreateProductCommand : IRequest<ProductResponseApplicationDto>
    {
        public ProductRequestApplicationDto Product { get; set; }
    }
}

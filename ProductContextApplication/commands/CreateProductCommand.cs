using MediatR;
using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.commands
{
    public class CreateProductCommand : IRequest<ProductResponseApplicationDto>
    {
        public ProductRequestApplicationDto Product { get; private set; }
        public CreateProductCommand(ProductRequestApplicationDto product)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
        }
    }
}


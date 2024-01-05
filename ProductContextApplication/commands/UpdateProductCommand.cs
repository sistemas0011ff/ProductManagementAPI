using MediatR;
using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.commands
{ 
    public class UpdateProductCommand : IRequest<UpdateProductResponseDto>
    {
        public ProductUpdateApplicationDto Product { get; set; }

        public UpdateProductCommand(ProductUpdateApplicationDto product)
        {
            Product = product;
        }
    }
}
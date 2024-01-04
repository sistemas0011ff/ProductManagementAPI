using MediatR;
using ProductManagementAPI.Product.Application.dto;
public class UpdateProductCommand : IRequest<UpdateProductResponseDto>
{
    public ProductUpdateApplicationDto Product { get; set; }

    public UpdateProductCommand(ProductUpdateApplicationDto product)
    {
        Product = product;
    }
}
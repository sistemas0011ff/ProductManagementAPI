using MediatR;
using ProductManagementAPI.Product.Application.commands;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;

namespace ProductManagementAPI.Product.Application.usecases
{
    public class ProductCreateUseCase : IProductCreateUseCase
    {

        private readonly IMediator _mediator;

        public ProductCreateUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ProductResponseApplicationDto> CreateProductAsync(ProductRequestApplicationDto request)
        {
             
            try
            {
                var command = new CreateProductCommand { Product = request };
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            { 
                return new ProductResponseApplicationDto
                {
                    Success = false,
                    Message = $"Error al crear el producto: {ex.Message}"
                };
            }
        }
    }
}

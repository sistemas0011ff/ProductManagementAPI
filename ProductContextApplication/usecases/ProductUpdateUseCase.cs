using MediatR;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;

namespace ProductManagementAPI.Product.Application.usecases
{
    public class ProductUpdateUseCase : IProductUpdateUseCase
    {
        private readonly IMediator _mediator;

        public ProductUpdateUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<UpdateProductResponseDto> UpdateProductAsync(ProductUpdateApplicationDto request)
        {
            try
            {
                var command = new UpdateProductCommand(request);
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            { 
                return new UpdateProductResponseDto
                {
                    Success = false,
                    Message = $"Error updating product: {ex.Message}"
                };
            }
        }
    }
}

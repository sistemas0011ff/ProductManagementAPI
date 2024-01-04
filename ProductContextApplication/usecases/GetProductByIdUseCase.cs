using MediatR;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;
using ProductManagementAPI.Product.Application.queries;

namespace ProductManagementAPI.Product.Application.usecases
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IMediator _mediator;

        public GetProductByIdUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ProductApplicationDto> ExecuteAsync(string productId)
        {
            var query = new GetProductByIdQuery(productId); 
            return await _mediator.Send(query);
        }
    }
}

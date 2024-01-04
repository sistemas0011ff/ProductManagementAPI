using MediatR;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;
using ProductManagementAPI.Product.Application.queries;

namespace ProductManagementAPI.Product.Application.usecases
{
    public class GetProductStateByIdUseCase : IGetProductStateByIdUseCase
    {
        private readonly IMediator _mediator;

        public GetProductStateByIdUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ProductStateDto> ExecuteAsync(int stateId)
        {
            var query = new GetProductStateByIdQuery { StateId = stateId };
            var result = await _mediator.Send(query);
            return result ?? throw new KeyNotFoundException("State not found.");
        }
    }
}

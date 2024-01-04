using MediatR;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;
using ProductManagementAPI.Product.Application.queries;

public class GetProductStatesUseCase : IGetProductStatesUseCase
{
    private readonly IMediator _mediator;

    public GetProductStatesUseCase(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IEnumerable<ProductStateDto>> ExecuteAsync()
    {
        return await _mediator.Send(new GetProductStatesQuery());
    }
}


using MediatR;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;
using ProductManagementAPI.Product.Application.queries;
using ProductManagementAPI.Product.Domain.valueObjects;

namespace ProductManagementAPI.Product.Application.usecases
{
    public class GetDiscountByIdUseCase : IGetDiscountByIdUseCase
    {
        private readonly IMediator _mediator;

        public GetDiscountByIdUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<DiscountApplicationDto> ExecuteAsync(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException("Product ID cannot be null or whitespace.", nameof(productId));
            }

            var query = new GetProductDiscountQuery(new ProductId(productId));
            var discountDto = await _mediator.Send(query);

            if (discountDto == null)
            {
                return new DiscountApplicationDto
                {
                    Id = productId,
                    DiscountPercent = 0
                };
            }

            return new DiscountApplicationDto
            {
                Id = discountDto.Id,
                DiscountPercent = discountDto.DiscountPercent
            };
        }
    }
}

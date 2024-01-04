using MediatR;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Domain.interfaces;

namespace ProductManagementAPI.Product.Application.queries
{
    public class GetProductDiscountQueryHandler : IRequestHandler<GetProductDiscountQuery, DiscountApplicationDto>
    {
        private readonly IDiscountRepository _discountRepository;

        public GetProductDiscountQueryHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<DiscountApplicationDto> Handle(GetProductDiscountQuery request, CancellationToken cancellationToken)
        {
            var discountDomainDto = await _discountRepository.GetDiscountForProductAsync(request.ProductId.Value);
            return new DiscountApplicationDto
            {
                Id = discountDomainDto.Id,
                DiscountPercent = discountDomainDto.DiscountPercent
            };
        }
    }
}

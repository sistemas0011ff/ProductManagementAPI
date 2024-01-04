using MediatR;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Domain.interfaces;

namespace ProductManagementAPI.Product.Application.queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductApplicationDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductApplicationDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productInfrastructureDto = await _productRepository.GetByIdAsync(request.ProductId);
            if (productInfrastructureDto == null)
            {
                return null;
            }
             
            return new ProductApplicationDto
            {
                ProductId = productInfrastructureDto.ProductId,
                Name = productInfrastructureDto.Name,
                Status = productInfrastructureDto.Status,
                Stock = productInfrastructureDto.Stock,
                Description = productInfrastructureDto.Description,
                Price = productInfrastructureDto.Price,
                Discount = 0, 
                FinalPrice = productInfrastructureDto.Price 
            };
        }
    }
}

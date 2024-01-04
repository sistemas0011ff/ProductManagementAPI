using MediatR;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Domain.interfaces;

namespace ProductManagementAPI.Product.Application.commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponseDto>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<UpdateProductResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetByIdAsync(request.Product.ProductId);
            if (existingProduct == null)
            {
                return new UpdateProductResponseDto
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            existingProduct.Name = request.Product.Name;
            existingProduct.Status = request.Product.Status;
            existingProduct.Stock = request.Product.Stock;
            existingProduct.Description = request.Product.Description;
            existingProduct.Price = request.Product.Price;

            await _productRepository.UpdateAsync(existingProduct);

            return new UpdateProductResponseDto
            {
                Success = true,
                Message = "Product updated successfully.",
                UpdatedProduct = new ProductUpdateApplicationDto
                {
                    ProductId =  existingProduct.ProductId, 
                    Name = existingProduct.Name,
                    Status = existingProduct.Status,
                    Stock = existingProduct.Stock,
                    Description = existingProduct.Description,
                    Price = existingProduct.Price
                }
            };
        }
    
    }
}

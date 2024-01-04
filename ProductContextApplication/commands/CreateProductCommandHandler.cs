using MediatR;
using ProductManagementAPI.Product.Application.dto; 
using ProductManagementAPI.Product.Application.interfaces; 
using ProductManagementAPI.Product.Domain.dto;
using ProductManagementAPI.Product.Domain.events; 
using ProductManagementAPI.Product.Domain.interfaces;
using ProductManagementAPI.Product.Domain.valueObjects;

namespace ProductManagementAPI.Product.Application.commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponseApplicationDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventStore _eventStore;
        private readonly IProductFactory _productFactory;

        public CreateProductCommandHandler( IProductRepository productRepository,  IEventStore eventStore, IProductFactory productFactory)
        {
            _productRepository = productRepository;
            _eventStore = eventStore;
            _productFactory = productFactory;
        }

        public async Task<ProductResponseApplicationDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var estadoPrd = new ProductStatus(request.Product.Status);
                var productCreationDto = new ProductCreationDto
                {
                    Name = request.Product.Name,
                    Price = request.Product.Price,
                    Stock = request.Product.Stock,
                    Description = request.Product.Description,
                    Status = estadoPrd.Value 
                };
                var newProduct = _productFactory.CreateProduct(productCreationDto);
                
                var domainProduct = new ProductInfrastructureDto
                {
                    ProductId = newProduct.ProductId.Value,   
                    Name = newProduct.Name,   
                    Status = newProduct.Status.Value,   
                    Stock = newProduct.Stock,   
                    Description = newProduct.Description,   
                    Price = newProduct.Price
                };
                 
                await _productRepository.AddAsync(domainProduct);
                
                var createdEvent = new ProductCreatedEvent(newProduct);
                await _eventStore.Store(createdEvent);

                return new ProductResponseApplicationDto { Success = true, Message = "Producto creado con éxito", CreatedProduct = newProduct };
            }
            catch (Exception ex)
            {
                return new ProductResponseApplicationDto { Success = false, Message = ex.Message };
            }
        }
    }
}

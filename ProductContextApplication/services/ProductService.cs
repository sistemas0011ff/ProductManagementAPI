using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.helpers;
using ProductManagementAPI.Product.Application.interfaces;
using ProductManagementAPI.Product.Application.mappers;

namespace ProductManagementAPI.Product.Application.services
{
    public class ProductService : IProductService
    {
        private readonly IProductCreateUseCase _productCreateUseCase;
        private readonly IGetProductStateByIdUseCase _getStateByIdUseCase;
        private readonly IGetDiscountByIdUseCase _getDiscountByIdUseCase;
        private readonly IGetProductByIdUseCase _getProductByIdUseCase;
        private readonly IProductUpdateUseCase _productUpdateUseCase;

        public ProductService(
           IProductCreateUseCase productCreateUseCase,
           IGetProductStateByIdUseCase getStateByIdUseCase,
           IGetDiscountByIdUseCase getDiscountByIdUseCase,
           IGetProductByIdUseCase getProductByIdUseCase,
           IProductUpdateUseCase productUpdateUseCase)
        {
            _productCreateUseCase = productCreateUseCase;
            _getStateByIdUseCase = getStateByIdUseCase;
            _getDiscountByIdUseCase = getDiscountByIdUseCase;
            _getProductByIdUseCase = getProductByIdUseCase;
            _productUpdateUseCase = productUpdateUseCase;
        }


        /// <summary>
        /// Creates a new product asynchronously based on the provided product data transfer object.
        /// </summary>
        /// <param name="productDto">The product data transfer object containing the product details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the newly created <see cref="ProductApplicationDto"/> object.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the product creation is unsuccessful.</exception>
        /// <example>
        /// This example shows how to call the <see cref="CreateProductAsync"/> method:
        /// <code>
        /// var productDto = new ProductApplicationDto
        /// {
        ///     Name = "New Product",
        ///     Status = 1,
        ///     Stock = 100,
        ///     Description = "Description of the new product",
        ///     Price = 9.99M
        /// };
        /// var productService = new ProductService(productCreateUseCase);
        /// var createdProduct = await productService.CreateProductAsync(productDto);
        /// Console.WriteLine($"Product created with ID: {createdProduct.ProductId}");
        /// </code>
        /// </example>
        public async Task<ProductApplicationDto> CreateProductAsync(ProductApplicationDto productDto)
        {
            try
            {
                var request = ProductManagementAPI.Product.Application.mappers.ProductMapper.MapToProductRequest(productDto);
                var response = await _productCreateUseCase.CreateProductAsync(request);

                if (!response.Success)
                {
                    return ProductManagementAPI.Product.Application.handlers.ErrorHandler.HandleProductCreationFailure(response);
                }

                return ProductManagementAPI.Product.Application.mappers.ProductMapper.ToApplicationDto(response.CreatedProduct);
            }
            catch (Exception ex)
            { 
                throw new ApplicationException($"Error creating product:{ex.Message}", ex);
            }
        }
         
        /// <summary>
        /// Retrieves the details of a single product by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. 
        /// The task result contains the <see cref="ProductApplicationDto"/> object with product details.</returns>
        /// <exception cref="ApplicationException">Thrown when no product is found with the given identifier.</exception>
        /// <example>
        /// This example shows how to call the <see cref="GetProductByIdAsync"/> method:
        /// <code>
        /// var productId = "ac5e931c-28b8-4c2f-b3ca-53b8060506bb";
        /// var productService = new ProductService(productCreateUseCase, productDetailsUseCase);
        /// var productDetails = await productService.GetProductByIdAsync(productId);
        /// Console.WriteLine($"Name: {productDetails.Name}, Price: {productDetails.Price}");
        /// </code>
        /// </example>
        public async Task<ProductApplicationDto> GetProductByIdAsync(string id)
        {
            try
            {
                var productDto = await _getProductByIdUseCase.ExecuteAsync(id);
                ProductValidationHelper.EnsureNotNull(productDto, $"Product with ID {id} not found.");

                var discountDto = await _getDiscountByIdUseCase.ExecuteAsync(id);
                ProductValidationHelper.EnsureNotNull(discountDto, $"Discount for product ID {id} not found.");

                var statusDto = await _getStateByIdUseCase.ExecuteAsync(productDto.Status);
                ProductValidationHelper.EnsureNotNull(statusDto, $"Status for product ID {id} not found.");
            
                var product = GetProductByIdMapper.MapToDomainEntity(productDto);

                return GetProductByIdMapper.MapToApplicationDto(product, statusDto, discountDto);
            }
            catch (Exception ex)
            { 
                throw new ApplicationException($"An error occurred while retrieving product with ID {id}. :{ex.Message}", ex);
            }

        }
        
        public async Task<UpdateProductResponseDto> UpdateProductAsync(ProductUpdateApplicationDto productUpdateDto)
        {
            try
            { 
                return await _productUpdateUseCase.UpdateProductAsync(productUpdateDto);
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException($"Error updating product:{ex.Message}", ex);
            }
        }
        
    }
}

using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Controllers.Product.dto;
using ProductManagementAPI.Controllers.Product.Mappers;
using ProductManagementAPI.Product.Application.interfaces;

namespace ProductManagementAPI.Controllers.Productos
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <remarks>
        /// Example request:
        ///
        ///     POST /Product
        ///     {
        ///        "name": "Espresso Machine",
        ///        "status": 0,
        ///        "stock": 50,
        ///        "description": "Automatic espresso machine with integrated grinder",
        ///        "price": 129.99
        ///     }
        ///
        /// </remarks>
        /// <param name="productDto">DTO for the product to create.</param>
        /// <returns>Response with details of the created product.</returns>
        /// <response code="201">Returns the newly created product.</response>
        /// <response code="400">If the product is null.</response>
       
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var appProductDto = ProductMapper.MapToProductApplicationDto(productDto);
                var createdProduct = await _productService.CreateProductAsync(appProductDto);
                var createdProductResponse = ProductMapper.MapToProductCreateResponseDto(createdProduct);

                return CreatedAtAction(nameof(CreateProduct), new { id = createdProductResponse.ProductId }, createdProductResponse);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, $"Error creating product:{ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error:{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        
        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     GET /Product/9dbc6938-1686-4e46-b2b0-a3e890343bca
        ///
        /// </remarks>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns>An ActionResult of type ProductApplicationDto containing the product details.</returns>
        /// <response code="200">Returns the requested product.</response>
        /// <response code="404">If a product with the provided ID is not found.</response>            
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            try
            {
                var productApplicationDto = await _productService.GetProductByIdAsync(id);
                if (productApplicationDto == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                var productResponse = ProductMapper.MapToProductoGetResponseDto(productApplicationDto);
                return Ok(productResponse);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, $"Error retrieving product with ID {id} : {ex.Message}");
                return BadRequest(ex.Message); // Devuelve el mensaje de la excepción
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error :  {ex.Message}");
                return StatusCode(500, ex.Message); // Devuelve el mensaje de la excepción
            }
        }
         
        /// <summary>
        /// Updates the details of a specific product.
        /// </summary>
        /// <remarks>
        /// This API endpoint allows for updating the information of a product identified by its unique ID.
        /// The updated product details are provided in the request body.
        /// 
        /// Sample request:
        ///
        ///     PUT /product/{id}
        ///     {
        ///         "name": "Updated Product Name",
        ///         "price": 150.00,
        ///         "description": "Updated Description",
        ///         "status": 1,
        ///         "stock": 50
        ///     }
        ///
        /// </remarks>
        /// <param name="id">The unique identifier of the product to update.</param>
        /// <param name="productUpdateDto">The DTO containing updated product information.</param>
        /// <returns>An ActionResult containing the updated product information.</returns>
        /// <response code="200">If the product is successfully updated.</response>
        /// <response code="400">If the request is invalid or if the update operation fails due to business rules.</response>
        /// <response code="500">If an unexpected error occurs.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productApplicationDto = ProductMapper.MapToUpdateApplicationDto(id, productUpdateDto);
                var updateResult = await _productService.UpdateProductAsync(productApplicationDto);

                if (!updateResult.Success)
                {
                    return BadRequest(updateResult.Message);
                }

                var updatedProductResponse = ProductMapper.MapToUpdateResponseDto(updateResult);
                return Ok(updatedProductResponse);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex,$"Error updating product:{ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error:{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
         
    }
}

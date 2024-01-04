using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Controllers.Product.dto
{
    [SwaggerSchema(Title = "Product Creation Data", Description = "Data required for creating a new product")]
    public class ProductDto
    {
        [Required(ErrorMessage = "The product name is required and cannot be empty.")]
        [StringLength(100, ErrorMessage = "The product name must not exceed 100 characters.")]
        [SwaggerSchema(Description = "The name of the product.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The product status is required and must be either 0 (Inactive) or 1 (Active).")]
        [Range(0, 1, ErrorMessage = "The product status must be 0 (Inactive) or 1 (Active).")]
        [SwaggerSchema(Description = "The status of the product, where 0 is inactive and 1 is active.")]
        public int Status { get; set; }

        [Required(ErrorMessage = "The stock quantity is required and must be a non-negative integer.")]
        [Range(0, int.MaxValue, ErrorMessage = "The stock quantity must be a non-negative integer.")]
        [SwaggerSchema(Description = "The quantity of the product available in stock.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "The product description is required and cannot be empty.")]
        [SwaggerSchema(Description = "A brief description of the product.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The product price is required and must be greater than 0.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The product price must be greater than 0.")]
        [SwaggerSchema(Description = "The price of the product.")]
        public decimal Price { get; set; }
    }

}

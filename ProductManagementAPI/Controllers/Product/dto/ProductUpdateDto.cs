using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Controllers.Product.dto
{
    [SwaggerSchema(Title = "Product Update Data", Description = "Data for updating an existing product")]
    public class ProductUpdateDto
    {
        [StringLength(100, ErrorMessage = "The product name must not exceed 100 characters.")]
        [SwaggerSchema(Description = "The updated name of the product. Nullable if no update is required.")]
        public string Name { get; set; }

        [Range(0, 1, ErrorMessage = "The product status must be either 0 (Inactive) or 1 (Active).")]
        [SwaggerSchema(Description = "The updated status of the product, where 0 is inactive and 1 is active. Nullable if no update is required.")]
        public int? Status { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The stock quantity must be a non-negative integer.")]
        [SwaggerSchema(Description = "The updated stock quantity of the product. Nullable if no update is required.")]
        public int? Stock { get; set; }

        [SwaggerSchema(Description = "The updated description of the product. Nullable if no update is required.")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "The product price must be greater than 0.")]
        [SwaggerSchema(Description = "The updated price of the product. Nullable if no update is required.")]
        public decimal? Price { get; set; }
    }
}

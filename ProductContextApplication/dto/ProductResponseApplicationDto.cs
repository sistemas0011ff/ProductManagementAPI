namespace ProductManagementAPI.Product.Application.dto
{
    public class ProductResponseApplicationDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ProductManagementAPI.Product.Domain.aggregates.Product CreatedProduct { get; set; }
    }
}

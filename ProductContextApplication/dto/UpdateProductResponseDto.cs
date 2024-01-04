namespace ProductManagementAPI.Product.Application.dto
{
    public class UpdateProductResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ProductUpdateApplicationDto UpdatedProduct { get; set; }
    }
}

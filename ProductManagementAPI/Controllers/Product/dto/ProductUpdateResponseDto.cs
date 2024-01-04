namespace ProductManagementAPI.Controllers.Product.dto
{
    public class ProductUpdateResponseDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

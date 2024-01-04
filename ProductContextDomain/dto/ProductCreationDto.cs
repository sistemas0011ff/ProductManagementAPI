namespace ProductManagementAPI.Product.Domain.dto
{
    public class ProductCreationDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}

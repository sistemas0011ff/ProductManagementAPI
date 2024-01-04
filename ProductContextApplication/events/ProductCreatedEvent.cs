using ProductManagementAPI.Product.Domain.aggregates;

namespace ProductManagementAPI.Product.Domain.events
{
    public class ProductCreatedEvent
    {
        public string ProductId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; } 
        public ProductCreatedEvent(ProductManagementAPI.Product.Domain.aggregates.Product product)
        {
            ProductId = product.ProductId.Value;
            Name = product.Name;
            Price = product.Price;
        }
    }
}

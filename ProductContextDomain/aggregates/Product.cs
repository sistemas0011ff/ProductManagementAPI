using ProductManagementAPI.Product.Domain.entities;
using ProductManagementAPI.Product.Domain.valueObjects;

namespace ProductManagementAPI.Product.Domain.aggregates
{
    public class Product
    {
        public ProductId ProductId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Description { get; private set; }
         
        public ProductStatus Status { get; private set; }
         
        private Discount _discount;

        public Product(ProductId productId, string name, decimal price, int stock, string description, ProductStatus status)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Stock = stock;
            Description = description;
            Status = status;
        }

        public void ApplyDiscount(Discount discount)
        {
            _discount = discount;
        }

        public decimal CalculateFinalPrice()
        {
            return _discount != null ? Price * (100 - _discount.Percentage) / 100 : Price;
        }
         
    }
}

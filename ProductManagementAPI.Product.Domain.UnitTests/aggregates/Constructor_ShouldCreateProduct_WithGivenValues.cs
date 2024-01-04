
using ProductManagementAPI.Product.Domain.entities;
using ProductManagementAPI.Product.Domain.valueObjects;

namespace ProductManagementAPI.Product.Domain.UnitTests
{
    [TestClass]
    public class ProductTests
    {

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Constructor_ShouldFail_WhenGivenInvalidData()
        {
            // Arrange
            var productId = new ProductId(Guid.NewGuid().ToString());
            var name = "Test Product";
            var price = 100m;
            var stock = 10;
            var description = "Test Description";
            var status = new ProductStatus(1);

            // Act
            var product = new ProductManagementAPI.Product.Domain.aggregates.Product(productId, name, price, stock, description, status);

            // Assert - Intencionadamente fallará al verificar valores incorrectos
            Assert.IsNull(product, "El producto debería ser nulo");  
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ApplyDiscount_ShouldFail_WhenIncorrectDiscountApplied()
        {
            // Arrange
            var productId = new ProductId(Guid.NewGuid().ToString());
            var product = new ProductManagementAPI.Product.Domain.aggregates.Product(productId, "Test Product", 100m, 10, "Test Description", new ProductStatus(1));
            var discount = new Discount(10);

            // Act
            product.ApplyDiscount(discount);

            // Assert - Intentionally failing
            Assert.AreNotEqual(90m, product.CalculateFinalPrice(), "El precio final debería ser incorrecto"); // Esto fallará intencionalmente
        }

        [TestMethod]
        public void Constructor_ShouldCreateProduct_WithGivenValues()
        {
            // Arrange
            var productId = new ProductId(Guid.NewGuid().ToString());
            var name = "Test Product";
            var price = 100m;
            var stock = 10;
            var description = "Test Description";
            var status = new ProductStatus(1);  

            // Act
            var product = new ProductManagementAPI.Product.Domain.aggregates.Product(productId, name, price, stock, description, status);

            // Assert
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(stock, product.Stock);
            Assert.AreEqual(description, product.Description);
            Assert.AreEqual(status.Value, product.Status.Value);
        }

        [TestMethod]
        public void ApplyDiscount_ShouldSetDiscount_WhenGivenValidDiscount()
        {
            // Arrange
            var productId = new ProductId(Guid.NewGuid().ToString());
            var product = new ProductManagementAPI.Product.Domain.aggregates.Product(productId, "Test Product", 100m, 10, "Test Description", new ProductStatus(1));
            var discount = new Discount(10);

            // Act
            product.ApplyDiscount(discount);

            Assert.AreEqual(90m, product.CalculateFinalPrice());
        }

   
    }
}

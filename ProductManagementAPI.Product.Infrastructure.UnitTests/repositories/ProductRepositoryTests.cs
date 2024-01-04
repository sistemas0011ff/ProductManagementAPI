using Moq;
using ProductManagementAPI.Infrastructure.repositories;
using ProductManagementAPI.Product.Domain.dto;
using ProductManagementAPI.Product.Infrastructure.interfaces;

namespace ProductManagementAPI.Product.Infrastructure.UnitTests.repositories
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private readonly string _filePath = "testProducts.json";
        private Mock<IFileService> _mockFileService;
        private ProductRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            // Correctly set up the mock
            _mockFileService = new Mock<IFileService>();

            // Now pass the mock's Object, which is the correct type (IFileService), to the repository constructor
            _repository = new ProductRepository(_filePath, _mockFileService.Object);
            var simulatedFileContent = @"
            [
                {""ProductId"": ""0ab80db1-a295-4acf-9e8e-3cf01c37bbe6"", ""Name"": ""Producto de Prueba 1"", ""Price"": 100.0},
                {""ProductId"": ""9549c759-562d-4a8f-a294-e02491b56eb0"", ""Name"": ""Producto de Prueba 2"", ""Price"": 110.0},
                {""ProductId"": ""06ced812-f2f8-4d9d-8af2-22e7afb1b6ef"", ""Name"": ""Producto de Prueba 3"", ""Price"": 120.0},
                {""ProductId"": ""04a5e8ca-7956-4409-8074-c6516af9d7e2"", ""Name"": ""Producto de Prueba 4"", ""Price"": 130.0}
            ]";
            _mockFileService.Setup(service => service.ReadAsync(_filePath)).ReturnsAsync(simulatedFileContent);

            _mockFileService.Setup(service => service.WriteAsync(It.IsAny<string>(), It.IsAny<string>()))
                            .Returns(Task.CompletedTask);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task AddAsync_ShouldThrowNotImplementedException_IndicatingRedTDDPhase()
        {
            // Arrange
            var product = new ProductInfrastructureDto { ProductId = "6821203f-7cc8-43b3-814a-af32c1367af6", Name = "Test Product", Price = 100m };

            // Act
            var exception = await Assert.ThrowsExceptionAsync<NotImplementedException>(
                async () => await _repository.AddAsync(product)
            );

            // Assert
            Assert.IsNotNull(exception, "Expected a NotImplementedException as a part of the red phase in TDD to indicate the method is not yet implemented.");
        }

        [TestMethod]
        public async Task AddAsync_Should_Add_Product()
        { 
            var product = new ProductInfrastructureDto { ProductId = "6821203f-7cc8-43b3-814a-af32c1367af6", Name = "Test Product", Price = 100m };
             
            await _repository.AddAsync(product);
             
            _mockFileService.Verify(service => service.WriteAsync(_filePath, It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task GetByIdAsync_Should_Return_Product_If_Exists()
        {
            // Arrange
            var productId = "9549c759-562d-4a8f-a294-e02491b56eb0";
            var expectedProduct = new ProductInfrastructureDto { ProductId = productId, Name = "Test Product", Price = 100m };
            var productsList = new List<ProductInfrastructureDto> { expectedProduct };
            var productsJson = System.Text.Json.JsonSerializer.Serialize(productsList);
            _mockFileService.Setup(service => service.ReadAsync(_filePath)).ReturnsAsync(productsJson);

            // Act
            var product = await _repository.GetByIdAsync(productId);

            // Assert
            Assert.IsNotNull(product);
            Assert.AreEqual(expectedProduct.ProductId, product.ProductId);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task UpdateAsync_ShouldThrowException_IfProductDoesNotExist()
        {
            // Arrange
            var nonExistentProductId = "1149c759-562d-4a8f-a294-e02491b56eb0";
            var productToUpdate = new ProductInfrastructureDto { ProductId = nonExistentProductId, Name = "Non-existent Product", Price = 200m };
            var initialProductsList = new List<ProductInfrastructureDto>
            {
                new ProductInfrastructureDto { ProductId = "06ced812-f2f8-4d9d-8af2-22e7afb1b6ef", Name = "Existing Product", Price = 100m }
            };
            var initialProductsJson = System.Text.Json.JsonSerializer.Serialize(initialProductsList);
            _mockFileService.Setup(service => service.ReadAsync(_filePath)).ReturnsAsync(initialProductsJson);

            // Act
            await _repository.UpdateAsync(productToUpdate); 
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task GetByIdAsync_Should_Throw_If_Product_Does_Not_Exist()
        {
            // Arrange
            var productId = "6821203f-7cc8-43b3-814a-af32c1367af4"; // Assume this product does not exist

            // Act
            await _repository.GetByIdAsync(productId);

            // The ExpectedException attribute is expecting a KeyNotFoundException to be thrown
        }

        [TestMethod]
        public async Task UpdateAsync_Should_Update_Product_If_Exists()
        {
            // Arrange
            var productId = "0ab80db1-a295-4acf-9e8e-3cf01c37bbe6";
            var updatedProduct = new ProductInfrastructureDto { ProductId = productId, Name = "Updated Test Product", Price = 150m };
            var initialProductsList = new List<ProductInfrastructureDto>
            {
                new ProductInfrastructureDto { ProductId = productId, Name = "Test Product", Price = 100m }
            };
            var initialProductsJson = System.Text.Json.JsonSerializer.Serialize(initialProductsList);
            _mockFileService.Setup(service => service.ReadAsync(_filePath)).ReturnsAsync(initialProductsJson);

            // Act
            await _repository.UpdateAsync(updatedProduct);

            // Assert
            _mockFileService.Verify(service => service.WriteAsync(_filePath, It.IsAny<string>()), Times.Once);
        }
    }
}

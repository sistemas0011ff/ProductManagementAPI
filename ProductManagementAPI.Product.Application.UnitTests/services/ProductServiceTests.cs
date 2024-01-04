using Moq;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;
using ProductManagementAPI.Product.Application.services;
using ProductManagementAPI.Product.Domain.valueObjects;

namespace ProductManagementAPI.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        private readonly Mock<IProductCreateUseCase> _mockProductCreateUseCase;
        private readonly Mock<IGetProductStateByIdUseCase> _mockGetProductStateByIdUseCase;
        private readonly Mock<IGetDiscountByIdUseCase> _mockGetDiscountByIdUseCase;
        private readonly Mock<IGetProductByIdUseCase> _mockGetProductByIdUseCase;
        private readonly Mock<IProductUpdateUseCase> _mockProductUpdateUseCase;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockProductCreateUseCase = new Mock<IProductCreateUseCase>();
            _mockGetProductStateByIdUseCase = new Mock<IGetProductStateByIdUseCase>();
            _mockGetDiscountByIdUseCase = new Mock<IGetDiscountByIdUseCase>();
            _mockGetProductByIdUseCase = new Mock<IGetProductByIdUseCase>();
            _mockProductUpdateUseCase = new Mock<IProductUpdateUseCase>();

            _productService = new ProductService(
                _mockProductCreateUseCase.Object,
                _mockGetProductStateByIdUseCase.Object,
                _mockGetDiscountByIdUseCase.Object,
                _mockGetProductByIdUseCase.Object,
                _mockProductUpdateUseCase.Object
            );
        }

        /// <summary>
        /// Método de prueba para verificar que el método CreateProductAsync del ProductService
        /// falla adecuadamente cuando el caso de uso CreateProductAsync no está implementado.
        /// </summary>
        [TestMethod]
        public async Task CreateProductAsync_ShouldFail_WhenUseCaseIsNotImplemented()
        {
            // Arrange
            var productDto = new ProductApplicationDto
            {
                Name = "Espresso Machine",
                Status = 1,
                Stock = 50,
                Description = "Automatic espresso machine with integrated grinder",
                Price = 129.99m
            };

            // Configurando el mock para simular que el método aún no está implementado
            _mockProductCreateUseCase.Setup(useCase => useCase.CreateProductAsync(It.IsAny<ProductRequestApplicationDto>()))
                                     .ThrowsAsync(new NotImplementedException("Método CreateProductAsync no implementado"));

            // Act y Assert
            // Verificar que la llamada a CreateProductAsync en el servicio resulta en una NotImplementedException
            await Assert.ThrowsExceptionAsync<NotImplementedException>(() => _productService.CreateProductAsync(productDto));
        }


        /// <summary>
        /// Método de prueba para verificar que el método CreateProductAsync del ProductService
        /// funciona correctamente.
        /// </summary>
        [TestMethod]
        public async Task CreateProductAsync_ShouldSucceed_WhenUseCaseIsImplementedCorrectly()
        {
            // Arrange
            var productDto = new ProductApplicationDto
            {
                Name = "Espresso Machine",
                Status = 1,
                Stock = 50,
                Description = "Automatic espresso machine with integrated grinder",
                Price = 129.99m
            };

            var product = new Product.Domain.aggregates.Product(
                new ProductId("3ed9f774-67d8-4ea2-9ef2-ddc7eefea2d0"),
                productDto.Name,
                productDto.Price,
                productDto.Stock,
                productDto.Description,
                new ProductStatus(productDto.Status)
            );

            var response = new ProductResponseApplicationDto
            {
                Success = true,
                CreatedProduct = product
            };

            _mockProductCreateUseCase
                .Setup(useCase => useCase.CreateProductAsync(It.IsAny<ProductRequestApplicationDto>()))
                .ReturnsAsync(response);

            // Act
            var createdProductDto = await _productService.CreateProductAsync(productDto);

            // Assert
            Assert.IsNotNull(createdProductDto);
            Assert.AreEqual(productDto.Name, createdProductDto.Name);
            Assert.AreEqual(productDto.Status, createdProductDto.Status);
            Assert.AreEqual(productDto.Stock, createdProductDto.Stock);
            Assert.AreEqual(productDto.Description, createdProductDto.Description);
            Assert.AreEqual(productDto.Price, createdProductDto.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public async Task GetProductByIdAsync_ShouldThrowApplicationException_IfProductDoesNotExist()
        {
            // Arrange
            var nonExistingProductId = "non-existing-id";
            _mockGetProductByIdUseCase.Setup(useCase => useCase.ExecuteAsync(nonExistingProductId))
                                      .ReturnsAsync((ProductApplicationDto)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ApplicationException>(
                async () => await _productService.GetProductByIdAsync(nonExistingProductId),
                "Se esperaba una excepción al intentar obtener un producto que no existe."
            );
        }

        [TestMethod]
        public async Task GetProductByIdAsync_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var productId = "existing-id";
            var expectedProduct = new ProductApplicationDto
            {
                ProductId = productId,
                Name = "Test Product",
                Status = 1,
                Stock = 10,
                Description = "Test Description",
                Price = 100m,
                Discount = 0m,
                FinalPrice = 100m
            };

            var mockProductByIdUseCase = new Mock<IGetProductByIdUseCase>();
            var mockDiscountByIdUseCase = new Mock<IGetDiscountByIdUseCase>();
            var mockStateByIdUseCase = new Mock<IGetProductStateByIdUseCase>();

            mockProductByIdUseCase.Setup(useCase => useCase.ExecuteAsync(productId))
                                  .ReturnsAsync(expectedProduct);
            mockDiscountByIdUseCase.Setup(useCase => useCase.ExecuteAsync(productId))
                                   .ReturnsAsync(new DiscountApplicationDto { Id = productId, DiscountPercent = 0 });
            mockStateByIdUseCase.Setup(useCase => useCase.ExecuteAsync(It.IsAny<int>()))
                                .ReturnsAsync(new ProductStateDto { Id = 1, Name = "Active" });

            var productService = new ProductService(null, mockStateByIdUseCase.Object,
                                                    mockDiscountByIdUseCase.Object,
                                                    mockProductByIdUseCase.Object, null);

            // Act
            var resultProduct = await productService.GetProductByIdAsync(productId);

            // Assert
            Assert.IsNotNull(resultProduct);
            Assert.AreEqual(expectedProduct.ProductId, resultProduct.ProductId);
            Assert.AreEqual(expectedProduct.Name, resultProduct.Name);
            Assert.AreEqual(expectedProduct.Status, resultProduct.Status);
            Assert.AreEqual(expectedProduct.Stock, resultProduct.Stock);
            Assert.AreEqual(expectedProduct.Description, resultProduct.Description);
            Assert.AreEqual(expectedProduct.Price, resultProduct.Price);
            Assert.AreEqual(expectedProduct.Discount, resultProduct.Discount);
            Assert.AreEqual(expectedProduct.FinalPrice, resultProduct.FinalPrice);
        }



        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task UpdateProductAsync_ShouldThrowNotImplementedException()
        {
            var productUpdateDto = new ProductUpdateApplicationDto
            {
                ProductId = "existing-product-id", // ID de un producto existente en el sistema
                Name = "Updated Product Name",
                Status = 1, // Suponiendo que 0 es inactivo y 1 es activo
                Stock = 75, // Nueva cantidad en inventario
                Description = "Updated description of the product",
                Price = 149.99M // Precio actualizado del producto
            };
            // Act
            await _productService.UpdateProductAsync(productUpdateDto);

            // Assert is handled by the ExpectedException attribute
        }

        [TestMethod]
        public async Task UpdateProductAsync_ShouldSucceed_WhenValidInputIsProvided()
        {
            // Arrange
            var productUpdateDto = new ProductUpdateApplicationDto
            {
                ProductId = "existing-product-id",
                Name = "Updated Product Name",
                Status = 1,
                Stock = 75,
                Description = "Updated description of the product",
                Price = 149.99M
            };

            // Configurar el mock del caso de uso correspondiente para simular una actualización exitosa
            _mockProductUpdateUseCase.Setup(useCase =>
                useCase.UpdateProductAsync(It.IsAny<ProductUpdateApplicationDto>()))
                .ReturnsAsync(new UpdateProductResponseDto { Success = true });

            // Act
            var response = await _productService.UpdateProductAsync(productUpdateDto);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success); // Asegurar que la respuesta indica una operación exitosa
        }

    }
}

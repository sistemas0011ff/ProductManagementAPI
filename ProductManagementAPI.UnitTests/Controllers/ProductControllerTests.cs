using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProductManagementAPI.Controllers.Product.dto;
using ProductManagementAPI.Controllers.Product.dto.ProductManagementAPI.Controllers.Product.dto;
using ProductManagementAPI.Controllers.Productos;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;

namespace ProductManagementAPI.UnitTests.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        private ProductController _controller;
        private Mock<IProductService> _mockService;
        private Mock<ILogger<ProductController>> _mockLogger;

        [TestInitialize]
        public void Setup()
        {
            _mockService = new Mock<IProductService>();
            _mockLogger = new Mock<ILogger<ProductController>>();
            _controller = new ProductController(_mockService.Object, _mockLogger.Object);
        }

        /// <summary>
        /// Método de prueba para verificar que el método CreateProduct del ProductController
        /// falla adecuadamente cuando el método CreateProductAsync del ProductService no está implementado.
        /// Esta prueba corresponde a la fase 'Roja' de TDD (Desarrollo Guiado por Pruebas),
        /// donde se espera que la prueba falle debido a la funcionalidad no implementada.
        /// </summary>
        [TestMethod]
        public async Task CreateProduct_ShouldFail_WhenProductServiceIsNotImplemented()
        {
            // Arrange
            // Configuración de un objeto ProductDto con datos de prueba
            var productDto = new ProductDto
            {
                Name = "Espresso Machine",
                Status = 1,
                Stock = 50,
                Description = "Automatic espresso machine with integrated grinder",
                Price = 129.99m
            };

            // Método aún no  implementado
            _mockService.Setup(s => s.CreateProductAsync(It.IsAny<ProductApplicationDto>()))
                        .ThrowsAsync(new NotImplementedException());

            // Act y Assert
            // Verificar que llamar a CreateProduct en el controlador lanza una NotImplementedException,
            // indicando que el método del servicio del que depende no está implementado.
            await Assert.ThrowsExceptionAsync<NotImplementedException>(() => _controller.CreateProduct(productDto));
        }
         

        /// <summary>
        /// Método de prueba para verificar que el método GetProduct del ProductController
        /// falla adecuadamente cuando el método GetProductByIdAsync del ProductService no está implementado.
        /// Esta prueba es parte de la fase 'Roja' de TDD (Desarrollo Guiado por Pruebas),
        /// donde se espera que la prueba falle debido a que la funcionalidad aún no ha sido implementada.
        /// </summary>
        [TestMethod]
        public async Task GetProduct_ShouldFail_WhenProductServiceIsNotImplemented()
        {
            // Arrange
            var productId = "3ed9f774-67d8-4ea2-9ef2-ddc7eefea2d0";

            // Método aún no está implementado
            _mockService.Setup(s => s.GetProductByIdAsync(productId))
                        .ThrowsAsync(new NotImplementedException());

            // Act y Assert
            // Verificar que llamar a GetProduct en el controlador lanza una NotImplementedException,
            // indicando que el método del servicio del que depende no está implementado.
            await Assert.ThrowsExceptionAsync<NotImplementedException>(() => _controller.GetProduct(productId));
        }

        /// <summary>
        /// Método de prueba para verificar que el método UpdateProduct del ProductController
        /// falla adecuadamente cuando el método UpdateProductAsync del ProductService no está implementado.
        /// Esta prueba es parte de la fase 'Roja' de TDD (Desarrollo Guiado por Pruebas),
        /// donde se espera que la prueba falle debido a que la funcionalidad de actualización aún no ha sido implementada.
        /// </summary>
        [TestMethod]
        public async Task UpdateProduct_ShouldFail_WhenProductServiceUpdateIsNotImplemented()
        {
            // Arrange
            var productId = Guid.NewGuid().ToString();
            var productUpdateDto = new ProductUpdateDto
            {
                Name = "Updated Espresso Machine",
                Status = 1,
                Stock = 25,
                Description = "Updated description for the espresso machine",
                Price = 149.99m
            };
            _mockService.Setup(s => s.UpdateProductAsync(It.IsAny<ProductUpdateApplicationDto>()))
                        .ThrowsAsync(new NotImplementedException());

            // Act y Assert
            // Verificar que llamar a UpdateProduct en el controlador lanza una NotImplementedException,
            // indicando que el método del servicio del que depende no está implementado.
            await Assert.ThrowsExceptionAsync<NotImplementedException>(() => _controller.UpdateProduct(productId, productUpdateDto));
        }

        /// <summary>
        /// Testea que el método CreateProduct del ProductController retorna correctamente un producto creado.
        /// Este test corresponde a la fase verde del TDD, donde se verifica que la implementación actual satisface la prueba previamente escrita en la fase roja.
        /// </summary>
        [TestMethod]
        public async Task CreateProduct_ShouldReturnCreatedProduct_WhenProductIsSuccessfullyCreated()
        {
            // Arrange
            // Preparación de un DTO de producto con los datos para crear un nuevo producto.
            var productDto = new ProductDto
            {
                Name = "Espresso Machine",
                Status = 1,
                Stock = 50,
                Description = "Automatic espresso machine with integrated grinder",
                Price = 129.99m
            };

            // Simulación de un ID de producto generado que se espera como parte del producto creado.
            var productId = Guid.NewGuid().ToString();

            // Creación de un DTO de aplicación de producto que se espera que el servicio de aplicación retorne
            // al crear el producto exitosamente.
            var appProductDto = new ProductApplicationDto
            {
                ProductId = productId,
                Name = productDto.Name,
                Status = productDto.Status,
                Stock = productDto.Stock,
                Description = productDto.Description,
                Price = productDto.Price,
                Discount = null, // El descuento se calcula en otra parte
                FinalPrice = productDto.Price // Precio final es igual al precio si no hay descuento
            };

            // Configuración del mock del servicio de aplicación para devolver el DTO de aplicación de producto
            // cuando el método CreateProductAsync sea invocado con cualquier DTO de aplicación de producto.
            _mockService.Setup(s => s.CreateProductAsync(It.IsAny<ProductApplicationDto>()))
                        .ReturnsAsync(appProductDto);

            // Act
            // Invocación del método CreateProduct en el controlador con el DTO de producto proporcionado.
            var actionResult = await _controller.CreateProduct(productDto);

            // Assert
            // Verificación de que la acción ha resultado en un CreatedAtActionResult con el estado HTTP 201,
            // lo que indica que el recurso fue creado exitosamente.
            var createdAtActionResult = actionResult as CreatedAtActionResult;
            Assert.IsNotNull(createdAtActionResult);
            Assert.AreEqual(201, createdAtActionResult.StatusCode);

            // Verificación de que el valor retornado en la acción es equivalente al DTO de respuesta de producto esperado,
            // confirmando que los datos del producto creado coinciden con los datos proporcionados.
            var responseDto = createdAtActionResult.Value as ProductCreateResponseDto;
            Assert.IsNotNull(responseDto);
            Assert.AreEqual(appProductDto.ProductId, responseDto.ProductId);
            Assert.AreEqual(appProductDto.Name, responseDto.Name);
            Assert.AreEqual(appProductDto.Status, responseDto.Status);
            Assert.AreEqual(appProductDto.Stock, responseDto.Stock);
            Assert.AreEqual(appProductDto.Description, responseDto.Description);
            Assert.AreEqual(appProductDto.Price, responseDto.Price);
        }


        [TestMethod]
        public async Task GetProduct_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var productId = "3ed9f774-67d8-4ea2-9ef2-ddc7eefea2d0";
            var expectedProduct = new ProductApplicationDto
            {
                ProductId = productId,
                Name = "PROD MODIFICADO",
                Status = 1,
                StatusName = "Activo",
                Stock = 11,
                Description = "PROD MOD LIBRO",
                Price = 100m,
                Discount = 10m,
                FinalPrice = 90m
            };

            _mockService.Setup(s => s.GetProductByIdAsync(productId))
                        .ReturnsAsync(expectedProduct);

            // Act
            var actionResult = await _controller.GetProduct(productId);

            // Assert
            var okResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okResult, "El resultado no debe ser null.");
            Assert.AreEqual(200, okResult.StatusCode, "El código de estado debe ser 200.");

            var productResponse = okResult.Value as ProductoGetResponseDto;
            Assert.IsNotNull(productResponse, "La respuesta no debe ser null.");
            Assert.AreEqual(expectedProduct.ProductId, productResponse.ProductId, "El ID del producto debe coincidir.");
            Assert.AreEqual(expectedProduct.Name, productResponse.Name, "El nombre del producto debe coincidir.");
            Assert.AreEqual(expectedProduct.Status, productResponse.Status, "El estado del producto debe coincidir.");
            Assert.AreEqual(expectedProduct.StatusName, productResponse.StatusName, "El nombre del estado del producto debe coincidir.");
            Assert.AreEqual(expectedProduct.Stock, productResponse.Stock, "El stock del producto debe coincidir.");
            Assert.AreEqual(expectedProduct.Description, productResponse.Description, "La descripción del producto debe coincidir.");
            Assert.AreEqual(expectedProduct.Price, productResponse.Price, "El precio del producto debe coincidir.");
            Assert.AreEqual(expectedProduct.Discount, productResponse.Discount, "El descuento del producto debe coincidir.");
            Assert.AreEqual(expectedProduct.FinalPrice, productResponse.FinalPrice, "El precio final del producto debe coincidir.");
        }


        [TestMethod]
        public async Task UpdateProduct_ShouldReturnUpdatedProduct_WhenProductIsSuccessfullyUpdated()
        {
            // Arrange
            var productId = Guid.NewGuid().ToString();
            var productUpdateDto = new ProductUpdateDto
            {
                Name = "Updated Espresso Machine",
                Status = 1,
                Stock = 25,
                Description = "Updated description for the espresso machine",
                Price = 149.99m
            };

            var expectedUpdatedProduct = new ProductUpdateApplicationDto
            {
                ProductId = productId,
                Name = productUpdateDto.Name,
                Status = productUpdateDto.Status.GetValueOrDefault(),
                Stock = productUpdateDto.Stock.GetValueOrDefault(),
                Description = productUpdateDto.Description,
                Price = productUpdateDto.Price.GetValueOrDefault()
            };

            var updateResultDto = new UpdateProductResponseDto
            {
                Success = true,
                Message = "",
                UpdatedProduct = expectedUpdatedProduct
            };

            _mockService.Setup(s => s.UpdateProductAsync(It.IsAny<ProductUpdateApplicationDto>()))
                        .ReturnsAsync(updateResultDto);

            // Act
            var actionResult = await _controller.UpdateProduct(productId, productUpdateDto);

            // Assert
            var okResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var updatedProductResponse = okResult.Value as ProductUpdateResponseDto;
            Assert.IsNotNull(updatedProductResponse);
            Assert.AreEqual(expectedUpdatedProduct.ProductId, updatedProductResponse.ProductId);
            Assert.AreEqual(expectedUpdatedProduct.Name, updatedProductResponse.Name);
            Assert.AreEqual(expectedUpdatedProduct.Status, updatedProductResponse.Status);
            Assert.AreEqual(expectedUpdatedProduct.Stock, updatedProductResponse.Stock);
            Assert.AreEqual(expectedUpdatedProduct.Description, updatedProductResponse.Description);
            Assert.AreEqual(expectedUpdatedProduct.Price, updatedProductResponse.Price);
        }


    }
}

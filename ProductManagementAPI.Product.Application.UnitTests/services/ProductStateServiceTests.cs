using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;
using ProductManagementAPI.Product.Application.services;

namespace ProductManagementAPI.Product.Application.UnitTests.services
{
    [TestClass]
    public class ProductStateServiceTests
    {
        private IMemoryCache _memoryCache;

        [TestInitialize]
        public void Initialize()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        [TestMethod]
        [ExpectedException(typeof(CasoDeUsoNoImplementadoException))] 
        public async Task LoadStatesAsync_ShouldThrowCasoDeUsoNoImplementadoException()
        {
            // Arrange
            var mockUseCase = new Mock<IGetProductStatesUseCase>();
            var mockCache = new Mock<IMemoryCache>();
            var mockLogger = new Mock<ILogger<ProductStateService>>();
            var cacheEntry = Mock.Of<ICacheEntry>();

            mockCache.Setup(m => m.CreateEntry(It.IsAny<object>())).Returns(cacheEntry);
             
            mockUseCase.Setup(useCase => useCase.ExecuteAsync())
                       .ThrowsAsync(new CasoDeUsoNoImplementadoException());

            var service = new ProductStateService(mockUseCase.Object, mockCache.Object, mockLogger.Object);

            // Act
            await service.LoadStatesAsync();
             
        }


        [TestMethod]
        public async Task LoadStatesAsync_ShouldLoadFromCache_WhenAvailable()
        {
            // Arrange
            var mockUseCase = new Mock<IGetProductStatesUseCase>();
            var mockLogger = new Mock<ILogger<ProductStateService>>();

            var expectedStates = new List<ProductStateDto>
            {
                new ProductStateDto { Id = 1, Name = "Active" },
                new ProductStateDto { Id = 2, Name = "Inactive" }
            };

            const string cacheKey = "ProductStates";
            _memoryCache.Set(cacheKey, expectedStates);

            var service = new ProductStateService(mockUseCase.Object, _memoryCache, mockLogger.Object);

            // Act
            var result = await service.LoadStatesAsync();

            // Assert
            mockUseCase.Verify(useCase => useCase.ExecuteAsync(), Times.Never);
            Assert.AreEqual(expectedStates, result);
        }
    } 
    public class CasoDeUsoNoImplementadoException : Exception
    {
        public CasoDeUsoNoImplementadoException()
            : base("Caso de uso no implementado")
        {
        }
    }
}

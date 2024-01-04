

using Moq;
using ProductManagementAPI.Infrastructure.Interfaces;
using ProductManagementAPI.Infrastructure.repositories;
using ProductManagementAPI.Product.Domain.dto;
using ProductManagementAPI.Product.Domain.interfaces;

namespace ProductManagementAPI.Product.Infrastructure.UnitTests.repositories
{
    [TestClass]
    public class DiscountRepositoryTests
    {
        private Mock<IApiClient> _mockApiClient;
        private IDiscountRepository _discountRepository;

        [TestInitialize]
        public void Setup()
        {
            _mockApiClient = new Mock<IApiClient>();
            var discountEndpoint = "http://fakeurl.com/api/discounts"; 
            _discountRepository = new DiscountRepository(_mockApiClient.Object, discountEndpoint);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task GetDiscountForProductAsync_ShouldFail_WhenNotImplemented()
        {
            // Arrange
            var productId = "test-product-id";
            _mockApiClient.Setup(client => client.GetAsync<DiscountDto>($"discounts/{productId}"))
                          .ThrowsAsync(new NotImplementedException());

            // Act & Assert
            await _discountRepository.GetDiscountForProductAsync(productId);
        }



        [TestMethod]
        public async Task GetDiscountForProductAsync_ShouldReturnDiscount_WhenProductExists()
        {
            // Arrange
            var productId = "test-product-id";
            var expectedDiscount = new DiscountDto { Id = productId, DiscountPercent = 10 };

            _mockApiClient.Setup(client => client.GetAsync<DiscountDto>($"discounts/{productId}"))
                          .ReturnsAsync(expectedDiscount);

            // Act
            var discount = await _discountRepository.GetDiscountForProductAsync(productId);

            // Assert
            Assert.IsNotNull(discount);
            Assert.AreEqual(expectedDiscount.Id, discount.Id);
            Assert.AreEqual(expectedDiscount.DiscountPercent, discount.DiscountPercent);
        }

    }
}

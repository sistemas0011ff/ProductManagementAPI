using Moq;
using ProductManagementAPI.Product.Infrastructure.interfaces;
using ProductManagementAPI.Product.Infrastructure.repositories;

namespace ProductManagementAPI.Product.Infrastructure.UnitTests.repositories
{
    [TestClass]
    public class ProductStateRepositoryTests
    {
        private Mock<IFileService> _mockFileService;
        private ProductStateRepository _repository;
        private string _filePath = "testStates.json";

        [TestInitialize]
        public void Initialize()
        {
            _mockFileService = new Mock<IFileService>();
            _repository = new ProductStateRepository(_filePath, _mockFileService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "Expected FileNotFoundException in the red phase of TDD when the states file does not exist.")]
        public async Task GetProductStatesAsync_ShouldThrow_FileNotFoundException_If_File_Does_Not_Exist()
        {
            // Configura el mock para lanzar una FileNotFoundException
            _mockFileService.Setup(service => service.ReadAsync(_filePath))
                            .Throws(new FileNotFoundException());

            // Llama al método, esperando que lance la excepción
            await _repository.GetProductStatesAsync();
        }
    }
}

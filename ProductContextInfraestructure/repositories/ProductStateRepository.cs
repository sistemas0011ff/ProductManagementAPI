using ProductManagementAPI.Product.Domain.dto;
using ProductManagementAPI.Product.Domain.interfaces;
using ProductManagementAPI.Product.Infrastructure.interfaces;
using System.Text.Json;

namespace ProductManagementAPI.Product.Infrastructure.repositories
{
    public class ProductStateRepository : IProductStateRepository
    {
        private readonly string _filePath;
        private readonly IFileService _fileService; 
        
        public ProductStateRepository(string filePath, IFileService fileService)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }
        public async Task<IEnumerable<ProductStateInfrastructureDto>> GetProductStatesAsync()
        {
            var fileContent = await _fileService.ReadAsync(_filePath); 
            if (string.IsNullOrEmpty(fileContent))
            {
                return new List<ProductStateInfrastructureDto>();
            }

            var estadosWrapper = JsonSerializer.Deserialize<EstadosWrapper>(fileContent);
            return estadosWrapper?.Estados ?? new List<ProductStateInfrastructureDto>();
        }
    }
}

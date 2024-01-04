
using System.Text.Json;
using ProductManagementAPI.Product.Domain.dto;
using ProductManagementAPI.Product.Domain.interfaces;
using ProductManagementAPI.Product.Infrastructure.interfaces;

namespace ProductManagementAPI.Infrastructure.repositories
{
    public class ProductRepository : IProductRepository
    { 
        private readonly string _filePath;
        private readonly IFileService _fileService;   
        public ProductRepository(string filePath, IFileService fileService)  
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));  
        }
        public async Task AddAsync(ProductInfrastructureDto product)
        {
            var products = await ReadAllAsync();
            products.Add(product);
            await WriteAllAsync(products);
        }

        public async Task<IEnumerable<ProductInfrastructureDto>> GetAllAsync()
        {
            return await ReadAllAsync();
        }
            
        public async Task<ProductInfrastructureDto> GetByIdAsync(string productId)
        {
            var products = await ReadAllAsync();
            var product = products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                throw new KeyNotFoundException($"No product found with ID {productId}.");
            }

            return product;
        }

        public async Task UpdateAsync(ProductInfrastructureDto product)
        {
            var products = await ReadAllAsync();
            var productToUpdate = products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (productToUpdate != null)
            {
                products.Remove(productToUpdate);
                products.Add(product);
                await WriteAllAsync(products);
            }
        }

        public async Task DeleteAsync(string productId)
        {
            var products = await ReadAllAsync();
            var productToDelete = products.FirstOrDefault(p => p.ProductId == productId);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                await WriteAllAsync(products);
            }
        }

        private async Task<List<ProductInfrastructureDto>> ReadAllAsync()
        { 
            var fileContent = await _fileService.ReadAsync(_filePath); // Cambio aquí
            if (string.IsNullOrEmpty(fileContent))
            {
                return new List<ProductInfrastructureDto>();
            }

            return JsonSerializer.Deserialize<List<ProductInfrastructureDto>>(fileContent) ?? new List<ProductInfrastructureDto>();
        }

        private async Task WriteAllAsync(List<ProductInfrastructureDto> products)
        {
          
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var content = JsonSerializer.Serialize(products, options);
            await _fileService.WriteAsync(_filePath, content);
        }
    }
}

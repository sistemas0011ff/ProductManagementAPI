using ProductManagementAPI.Product.Infrastructure.interfaces;

namespace ProductManagementAPI.Product.Infrastructure.Configuration
{
    public class FileService : IFileService
    {
        public async Task<string> ReadAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null; 
            }

            using (var reader = File.OpenText(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task WriteAsync(string filePath, string content)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            await File.WriteAllTextAsync(filePath, content);
        }
    }
}

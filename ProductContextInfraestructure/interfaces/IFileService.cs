namespace ProductManagementAPI.Product.Infrastructure.interfaces
{
    public interface IFileService
    {
        Task<string> ReadAsync(string filePath);
        Task WriteAsync(string filePath, string content);
    }
}


namespace ProductManagementAPI.Shared
{
    public interface ICommand
    {
        Task Validate();
    }
}

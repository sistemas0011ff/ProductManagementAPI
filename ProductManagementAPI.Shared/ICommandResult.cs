 

namespace ProductManagementAPI.Shared
{
    public interface ICommandResult<T, C>
    {
        T Result { get; }
        C Value { get; }
    }
}

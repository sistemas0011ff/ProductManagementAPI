namespace ProductManagementAPI.Shared
{
    public interface ICommandHandler<TCommand, TResult, T, C>
        where TCommand : ICommand
        where TResult : ICommandResult<T, C> 
    {
        Task<TResult> Handle(TCommand command);
    }
}

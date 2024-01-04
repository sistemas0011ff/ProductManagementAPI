 
namespace ProductManagementAPI.Product.Application.interfaces
{
    public interface IEventStore
    {
        Task Store<TEvent>(TEvent @event) where TEvent : class;
    }
}

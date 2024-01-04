using ProductManagementAPI.Product.Application.interfaces;

namespace ProductManagementAPI.Product.Application.events
{
    public class SimpleEventStore : IEventStore
    {
        public async Task Store<TEvent>(TEvent @event) where TEvent : class
        { 
            Console.WriteLine($"Evento almacenado: {@event.GetType().Name}");
            await Task.CompletedTask;
        }
    }
}

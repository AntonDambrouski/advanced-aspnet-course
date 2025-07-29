using TodoItems.Shared.Events;

namespace TodoItemsCommands.Api.Producers
{
    public interface IEventProducer
    {
        Task ProduceAsync<TEvent>(TEvent @event, CancellationToken cancellationToken)
            where TEvent : EventBase;
    }
}
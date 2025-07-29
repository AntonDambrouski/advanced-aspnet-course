using TodoItems.Shared.Events;
using TodoItems.Shared.Exceptions;
using TodoItemsQueries.Api.Data;

namespace TodoItemsQueries.Api.EventHandlers
{
    public class EventHandlerDispatcher(IDictionaryDatabase db) : IEventHandlerDispatcher
    {
        public IEventHandler GetHandler(string eventType)
        {
            return eventType switch
            {
                nameof(TodoItemCreatedEvent) => new TodoItemCreatedEventHandler(db),
                nameof(TodoItemUpdatedEvent) => new TodoItemUpdatedEventHandler(db),
                _ => throw new DomainException($"No handler found for event type: {eventType}")
            };
        }
    }
}

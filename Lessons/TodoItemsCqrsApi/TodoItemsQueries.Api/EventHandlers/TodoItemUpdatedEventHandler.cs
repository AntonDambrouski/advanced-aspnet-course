using System.Text.Json;
using TodoItems.Shared.Events;
using TodoItems.Shared.Exceptions;
using TodoItemsQueries.Api.Data;

namespace TodoItemsQueries.Api.EventHandlers
{
    public class TodoItemUpdatedEventHandler(IDictionaryDatabase db) : IEventHandler
    {
        public void Handle(string eventJson, CancellationToken cancellationToken)
        {
            var @event = JsonSerializer.Deserialize<TodoItemUpdatedEvent>(eventJson);
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(@event), "Event cannot be null");
            }

            var savedItem = db.GetTodoItemById(@event.TodoItemId);
            if (savedItem == null)
            {
                throw new DomainException($"Item with id: {@event.TodoItemId} not found");   
            }

            savedItem.Title = @event.Title;
            savedItem.Description = @event.Description;
            savedItem.IsCompleted = @event.IsCompleted;

            db.UpdateTodoItem(savedItem);
        }
    }
}

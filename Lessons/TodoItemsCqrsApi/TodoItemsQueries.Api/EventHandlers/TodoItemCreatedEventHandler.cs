using System.Text.Json;
using TodoItems.Shared.Events;
using TodoItemsQueries.Api.Data;
using TodoItemsQueries.Api.Models;

namespace TodoItemsQueries.Api.EventHandlers
{
    public class TodoItemCreatedEventHandler(IDictionaryDatabase db) : IEventHandler
    {
        public void Handle(string eventJson, CancellationToken cancellationToken)
        {
            var @event = JsonSerializer.Deserialize<TodoItemCreatedEvent>(eventJson);
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(@event), "Event cannot be null");
            }

            var todoItem = new TodoItemModel
            {
                Id = @event.TodoItemId,
                Title = @event.Title,
                Description = @event.Description,
                IsCompleted = @event.IsCompleted
            };

            db.AddTodoItem(todoItem);
        }
    }
}

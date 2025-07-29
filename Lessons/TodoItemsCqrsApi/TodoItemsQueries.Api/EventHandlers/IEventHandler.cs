using TodoItems.Shared.Events;

namespace TodoItemsQueries.Api.EventHandlers
{
    public interface IEventHandler
    {
        void Handle(string eventJson, CancellationToken cancellationToken);
    }
}
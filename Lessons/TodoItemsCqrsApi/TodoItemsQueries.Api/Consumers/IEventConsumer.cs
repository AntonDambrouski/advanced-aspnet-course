using TodoItems.Shared.Events;

namespace TodoItemsQueries.Api.Consumers
{
    public interface IEventConsumer
    {
        AppConsumeResult Consume(CancellationToken cancellationToken);
    }
}

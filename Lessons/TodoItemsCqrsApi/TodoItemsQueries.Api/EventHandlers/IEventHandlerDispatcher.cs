namespace TodoItemsQueries.Api.EventHandlers
{
    public interface IEventHandlerDispatcher
    {
        IEventHandler GetHandler(string eventType);
    }
}
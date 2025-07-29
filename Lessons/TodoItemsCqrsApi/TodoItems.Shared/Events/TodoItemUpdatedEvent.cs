namespace TodoItems.Shared.Events
{
    public class TodoItemUpdatedEvent : EventBase
    {
        public int TodoItemId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}

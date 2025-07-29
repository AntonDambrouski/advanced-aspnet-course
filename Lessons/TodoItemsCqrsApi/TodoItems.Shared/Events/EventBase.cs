namespace TodoItems.Shared.Events
{
    public abstract class EventBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}

namespace TodoItemsQueries.Api.Consumers
{
    public class AppConsumeResult
    {
        public string MessageJson { get; set; }
        public string EventType { get; set; }
        public AppConsumeResult(string messageJson, string eventType)
        {
            MessageJson = messageJson 
                ?? throw new ArgumentNullException(nameof(messageJson), "Message JSON cannot be null");

            EventType = eventType
                ?? throw new ArgumentNullException(nameof(eventType), "Event type cannot be null");
        }
    }
}

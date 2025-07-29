using Confluent.Kafka;
using System.Text;
using TodoItems.Shared.Constants;
using TodoItems.Shared.Events;

namespace TodoItemsQueries.Api.Consumers
{
    public class EventConsumer : IEventConsumer
    {
        private readonly IConsumer<Null, string> _consumer;

        public EventConsumer()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = SharedConstants.TodoItemsKafkaBootstrapServers,
                GroupId = SharedConstants.TodoItemsGroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            _consumer = new ConsumerBuilder<Null, string>(config).Build();

            _consumer.Subscribe("todo-items-events");
        }

        public AppConsumeResult Consume(CancellationToken cancellationToken)
        {
            var consumeResult = _consumer.Consume(cancellationToken);
            
            var messageJson = consumeResult.Message.Value;
            var eventTypeBytes = consumeResult.Message.Headers.GetLastBytes(SharedConstants.EventTypeHeader);
            var eventType = Encoding.UTF8.GetString(eventTypeBytes);

            return new AppConsumeResult(messageJson, eventType);
        }
    }
}

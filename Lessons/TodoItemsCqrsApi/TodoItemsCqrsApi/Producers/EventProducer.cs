using Confluent.Kafka;
using System.Text;
using System.Text.Json;
using TodoItems.Shared.Constants;
using TodoItems.Shared.Events;
using TodoItems.Shared.Exceptions;

namespace TodoItemsCommands.Api.Producers
{
    public class EventProducer : IEventProducer, IDisposable
    {
        private readonly IProducer<Null, string> _producer;

        public EventProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = SharedConstants.TodoItemsKafkaBootstrapServers,
                EnableIdempotence = true,
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public void Dispose()
        {
            _producer?.Dispose();
        }

        public async Task ProduceAsync<TEvent>(TEvent @event, CancellationToken cancellationToken)
            where TEvent : EventBase
        {
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(@event), "Event cannot be null");
            }

            var messageJson = JsonSerializer.Serialize(@event);
            var message = new Message<Null, string>
            {
                Value = messageJson
            };

            var eventType = @event.GetType().Name;
            var eventTypeBytes = Encoding.UTF8.GetBytes(eventType);
            message.Headers = new Headers
            {
                { SharedConstants.EventTypeHeader, eventTypeBytes }
            };

            try
            {
                var result = await _producer.ProduceAsync(SharedConstants.TodoItemsEventsTopic, message, cancellationToken);
                if (result.Status != PersistenceStatus.Persisted)
                {
                    throw new DomainException($"Failed to produce event to Kafka for event: {messageJson}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when producing event: {ex.Message}");
            }
        }
    }
}

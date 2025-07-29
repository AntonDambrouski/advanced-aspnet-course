using TodoItemsQueries.Api.Consumers;
using TodoItemsQueries.Api.EventHandlers;

namespace TodoItemsQueries.Api.Services
{
    public class ConsumerBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public ConsumerBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
          
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var eventConsumer = scope.ServiceProvider.GetRequiredService<IEventConsumer>();
            var handlerDispatcher = scope.ServiceProvider.GetRequiredService<IEventHandlerDispatcher>();
            var task = Task.Run(() => ExecuteImpl(eventConsumer, handlerDispatcher, stoppingToken), stoppingToken);

            return task;
        }

        public async Task ExecuteImpl(IEventConsumer eventConsumer, IEventHandlerDispatcher handlerDispatcher, CancellationToken stoppingToken)
        {
            while (true)
            {
                var consumeResult = eventConsumer.Consume(stoppingToken);
                if (stoppingToken.IsCancellationRequested)
                {
                    break;
                }

                var handler = handlerDispatcher.GetHandler(consumeResult.EventType);
                handler.Handle(consumeResult.MessageJson, stoppingToken);
            }
        }
    }
}

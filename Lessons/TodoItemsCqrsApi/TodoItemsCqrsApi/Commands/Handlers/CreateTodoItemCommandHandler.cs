using MediatR;
using TodoItems.Shared.Events;
using TodoItemsCommands.Api.Producers;
using TodoItemsCqrsApi.Data;
using TodoItemsCqrsApi.Entities;

namespace TodoItemsCqrsApi.Commands.Handlers
{
    public class CreateTodoItemCommandHandler(ApplicationContext context, IEventProducer eventProducer)
        : IRequestHandler<CreateTodoItemCommand, int>
    {
        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem
            {
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted,
            };

            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            var todoItemCreatedEvent = new TodoItemCreatedEvent
            {
                TodoItemId = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                IsCompleted = todoItem.IsCompleted
            };

            await eventProducer.ProduceAsync(todoItemCreatedEvent, cancellationToken);

            return todoItem.Id;
        }
    }
}

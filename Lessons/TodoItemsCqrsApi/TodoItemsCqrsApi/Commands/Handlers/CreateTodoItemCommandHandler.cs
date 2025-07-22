using MediatR;
using TodoItemsCqrsApi.Data;
using TodoItemsCqrsApi.Entities;

namespace TodoItemsCqrsApi.Commands.Handlers
{
    public class CreateTodoItemCommandHandler(ApplicationContext context) : IRequestHandler<CreateTodoItemCommand, int>
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

            return todoItem.Id;
        }
    }
}

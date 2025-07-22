using MediatR;
using TodoItemsCqrsApi.Data;

namespace TodoItemsCqrsApi.Commands.Handlers
{
    public class UpdateTodoItemCommandHandler(ApplicationContext context) : IRequestHandler<UpdateTodoItemCommand>
    {
        public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var storedItem = await context.TodoItems.FindAsync(request.Id, cancellationToken);
            if (storedItem == null)
            {
                throw new ArgumentNullException(nameof(storedItem));
            }

            storedItem.Title = request.Title;
            storedItem.Description = request.Description;
            storedItem.IsCompleted = request.IsCompleted;

            context.TodoItems.Update(storedItem);
            await context.SaveChangesAsync();
        }
    }
}

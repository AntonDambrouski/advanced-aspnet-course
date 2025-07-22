using MediatR;
using TodoItemsCqrsApi.Data;

namespace TodoItemsCqrsApi.Commands.Handlers
{
    public class DeleteTodoItemCommandHandler(ApplicationContext context) : IRequestHandler<DeleteTodoItemCommand, bool>
    {
        public async Task<bool> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var storedItem = await context.TodoItems.FindAsync(request.Id, cancellationToken);
            if (storedItem == null)
            {
                return true;
            }

            context.TodoItems.Remove(storedItem);
           return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}

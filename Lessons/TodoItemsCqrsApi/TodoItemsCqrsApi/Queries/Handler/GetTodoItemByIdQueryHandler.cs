using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoItemsCqrsApi.Data;
using TodoItemsCqrsApi.Entities;

namespace TodoItemsCqrsApi.Queries.Handler
{
    public class GetTodoItemByIdQueryHandler(ApplicationContext context) : IRequestHandler<GetTodoItemByIdQuery, TodoItem?>
    {
        public Task<TodoItem?> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            return context.TodoItems
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}

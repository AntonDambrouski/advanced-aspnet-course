using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoItemsCqrsApi.Data;
using TodoItemsCqrsApi.Entities;

namespace TodoItemsCqrsApi.Queries.Handler
{
    public class GetAllTodoItemsQueryHandler(ApplicationContext context) : IRequestHandler<GetAllTodoItemsQuery, List<TodoItem>>
    {
        public Task<List<TodoItem>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return context.TodoItems
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

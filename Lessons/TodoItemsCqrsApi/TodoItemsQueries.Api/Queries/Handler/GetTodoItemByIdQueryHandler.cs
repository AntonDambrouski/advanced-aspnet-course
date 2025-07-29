using MediatR;
using TodoItemsQueries.Api.Data;
using TodoItemsQueries.Api.Models;

namespace TodoItemsCqrsApi.Queries.Handler
{
    public class GetTodoItemByIdQueryHandler(IDictionaryDatabase db) : IRequestHandler<GetTodoItemByIdQuery, TodoItemModel?>
    {
        public Task<TodoItemModel?> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var todoItem = db.GetTodoItemById(request.Id);
            return Task.FromResult(todoItem);
        }
    }
}

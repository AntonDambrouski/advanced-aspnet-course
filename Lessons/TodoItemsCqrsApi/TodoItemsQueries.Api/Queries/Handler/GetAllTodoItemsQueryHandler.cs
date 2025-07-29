using MediatR;
using TodoItemsQueries.Api.Data;
using TodoItemsQueries.Api.Models;

namespace TodoItemsCqrsApi.Queries.Handler
{
    public class GetAllTodoItemsQueryHandler(IDictionaryDatabase db) : IRequestHandler<GetAllTodoItemsQuery, List<TodoItemModel>>
    {
        public Task<List<TodoItemModel>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var items = db.GetAllTodoItems();
            return Task.FromResult(items);
        }
    }
}

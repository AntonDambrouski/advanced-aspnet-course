using MediatR;
using TodoItemsQueries.Api.Models;

namespace TodoItemsCqrsApi.Queries
{
    public class GetAllTodoItemsQuery : IRequest<List<TodoItemModel>>
    {
    }
}

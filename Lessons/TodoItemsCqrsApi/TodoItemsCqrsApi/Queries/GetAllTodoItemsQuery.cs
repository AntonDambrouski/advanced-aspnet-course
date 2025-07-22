using MediatR;
using TodoItemsCqrsApi.Entities;

namespace TodoItemsCqrsApi.Queries
{
    public class GetAllTodoItemsQuery : IRequest<List<TodoItem>>
    {
    }
}

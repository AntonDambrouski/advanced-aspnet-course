using MediatR;
using TodoItemsQueries.Api.Models;

namespace TodoItemsCqrsApi.Queries
{
    public class GetTodoItemByIdQuery : IRequest<TodoItemModel?>
    {
        public GetTodoItemByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

using MediatR;
using TodoItemsCqrsApi.Entities;

namespace TodoItemsCqrsApi.Queries
{
    public class GetTodoItemByIdQuery : IRequest<TodoItem?>
    {
        public GetTodoItemByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

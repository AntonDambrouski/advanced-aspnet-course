using MediatR;

namespace TodoItemsCqrsApi.Commands
{
    public class DeleteTodoItemCommand : IRequest<bool>
    {
        public DeleteTodoItemCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

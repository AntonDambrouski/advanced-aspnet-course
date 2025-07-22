using MediatR;

namespace TodoItemsCqrsApi.Commands
{
    public class CreateTodoItemCommand : IRequest<int>
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}

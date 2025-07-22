using MediatR;

namespace TodoItemsCqrsApi.Commands
{
    public class UpdateTodoItemCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TodoItemsCqrsApi.Entities
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [MaxLength(100)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

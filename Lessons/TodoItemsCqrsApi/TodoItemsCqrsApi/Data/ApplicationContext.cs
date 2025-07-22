using Microsoft.EntityFrameworkCore;
using TodoItemsCqrsApi.Entities;

namespace TodoItemsCqrsApi.Data
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}

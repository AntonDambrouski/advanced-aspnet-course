using TodoItemsQueries.Api.Models;

namespace TodoItemsQueries.Api.Data
{
    public interface IDictionaryDatabase
    {
        void AddTodoItem(TodoItemModel todoItem);
        bool DeleteTodoItem(int id);
        List<TodoItemModel> GetAllTodoItems();
        TodoItemModel? GetTodoItemById(int id);
        void UpdateTodoItem(TodoItemModel todoItem);
    }
}
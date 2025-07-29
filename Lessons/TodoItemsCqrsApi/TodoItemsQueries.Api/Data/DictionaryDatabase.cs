using TodoItemsQueries.Api.Models;

namespace TodoItemsQueries.Api.Data
{
    public class DictionaryDatabase : IDictionaryDatabase
    {
        private static readonly Dictionary<int, TodoItemModel> _todoItems = new();

        public TodoItemModel? GetTodoItemById(int id)
        {
            _todoItems.TryGetValue(id, out var todoItem);
            return todoItem;
        }

        public List<TodoItemModel> GetAllTodoItems()
        {
            return _todoItems.Values.ToList();
        }

        public void AddTodoItem(TodoItemModel todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem), "Todo item cannot be null");
            }

            if (_todoItems.ContainsKey(todoItem.Id))
            {
                throw new InvalidOperationException($"Todo item with ID {todoItem.Id} already exists.");
            }

            _todoItems[todoItem.Id] = todoItem;
        }

        public void UpdateTodoItem(TodoItemModel todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem), "Todo item cannot be null");
            }

            if (!_todoItems.ContainsKey(todoItem.Id))
            {
                throw new KeyNotFoundException($"Todo item with ID {todoItem.Id} does not exist.");
            }

            _todoItems[todoItem.Id] = todoItem;
        }

        public bool DeleteTodoItem(int id)
        {
            return _todoItems.Remove(id);
        }
    }
}

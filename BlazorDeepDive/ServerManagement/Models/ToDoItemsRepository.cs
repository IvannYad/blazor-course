namespace ServerManagement.Models
{
    public static class ToDoItemsRepository
    {
        private static List<ToDoItem> todoItems = new List<ToDoItem>()
        {
            new ToDoItem { Id = 1, Name = "Wake up" },
            new ToDoItem { Id = 2, Name = "Go to school" },
            new ToDoItem { Id = 3, Name = "Swim" },
            new ToDoItem { Id = 4, Name = "Play a videogame" },
        };

        public static void AddToDoItem(ToDoItem item)
        {
            var maxId = todoItems.Max(s => s.Id);
            item.Id = maxId + 1;
            todoItems.Add(item);
        }

        public static List<ToDoItem> GetToDoItems()
        {
            return todoItems
                .OrderBy(it => it.IsCompleted)
                .ThenByDescending(i => i.Id)
                .ToList();
        }

        public static ToDoItem? GetToDoItemById(int id)
        {
            var server = todoItems.FirstOrDefault(s => s.Id == id);
            if (server != null)
            {
                return new ToDoItem
                {
                    Id = server.Id,
                    Name = server.Name,
                    IsCompleted = server.IsCompleted,
                    DateCompleted = server.DateCompleted,
                };
            }

            return null;
        }

        public static void UpdateToDoItem(int itemId, ToDoItem todoItem)
        {
            if (itemId != todoItem.Id) return;

            var itemToUpdate = todoItems.FirstOrDefault(s => s.Id == itemId);
            if (itemToUpdate != null)
            {
                itemToUpdate.IsCompleted = todoItem.IsCompleted;
                itemToUpdate.Name = todoItem.Name;
                itemToUpdate.DateCompleted = todoItem.IsCompleted ? DateTime.UtcNow : null;
            }
        }

        public static void DeleteToDoItem(int itemId)
        {
            var item = todoItems.FirstOrDefault(s => s.Id == itemId);
            if (item != null)
            {
                todoItems.Remove(item);
            }
        }

        public static List<ToDoItem> SearchServers(string itemsFilter)
        {
            return todoItems.Where(s => s.Name.Contains(itemsFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

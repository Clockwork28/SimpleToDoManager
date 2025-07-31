using SimpleToDoManager.Data;
using SimpleToDoManager.Interfaces;
using SimpleToDoManager.Models;

namespace SimpleToDoManager.Services
{
    public class ToDoService : IToDoService
    {
        private readonly AppDbContext _dbContext;
        public ToDoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ToDoItem? Add(string name)
        {
            try
            {
                ToDoItem item = new(name);
                _dbContext.ToDoItems.Add(item);
                _dbContext.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{e.Message}");
                Console.ResetColor();
                return null;
            }
        }
        public List<ToDoItem> GetAll()
        {
            var itemList = _dbContext.ToDoItems.ToList();
            return itemList;
        }

        public ToDoItem? MarkCompleted(Guid id)
        {
            var item = _dbContext.ToDoItems.Find(id);
            if (item == null) return null;
            item.IsCompleted = true;
            _dbContext.SaveChanges();
            return item;
        }

        public ToDoItem? Delete(Guid id)
        {
            var item = _dbContext.ToDoItems.Find(id);
            if (item == null) return null;
            try
            {
                _dbContext.ToDoItems.Remove(item);
                _dbContext.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{e.Message}");
                Console.ResetColor();
                return null;
            }
        }
    }
}

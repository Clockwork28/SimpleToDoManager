using SimpleToDoManager.Models;

namespace SimpleToDoManager.Interfaces
{
    public interface IToDoService
    {
        ToDoItem? Add(string name);
        List<ToDoItem> GetAll();
        ToDoItem? MarkCompleted(Guid id);
        ToDoItem? Delete(Guid id);
    }
}

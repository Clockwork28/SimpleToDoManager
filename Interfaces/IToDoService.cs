using SimpleToDoManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoManager.Interfaces
{
    public interface IToDoService
    {
        ToDoItem? Add(string Name);
        List<ToDoItem> GetAll();
        ToDoItem? MarkCompleted(int Index);
        ToDoItem? Delete(int Index);
    }
}

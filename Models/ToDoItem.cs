using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoManager.Models
{
    public class ToDoItem()
    {
       public Guid Id { get; init; } = Guid.NewGuid();
       public string Name { get; set; } = string.Empty;
       public bool IsCompleted { get; set; }
       public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }
}

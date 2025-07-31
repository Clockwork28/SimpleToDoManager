using Microsoft.EntityFrameworkCore;
using SimpleToDoManager.Models;

namespace SimpleToDoManager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}

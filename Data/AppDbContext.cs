using Microsoft.EntityFrameworkCore;
using SimpleToDoManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoManager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}

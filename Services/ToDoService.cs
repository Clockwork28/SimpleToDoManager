using Microsoft.EntityFrameworkCore;
using SimpleToDoManager.Data;
using SimpleToDoManager.Interfaces;
using SimpleToDoManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoManager.Services
{
    public class ToDoService : IToDoService
    {
        private readonly AppDbContext _dbContext;
        public ToDoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ToDoItem? Add(string Name)
        {
            throw new NotImplementedException();
        }

        public ToDoItem? Delete(int Index)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public ToDoItem? MarkCompleted(int Index)
        {
            throw new NotImplementedException();
        }
    }
}

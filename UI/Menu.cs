using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SimpleToDoManager.Interfaces;
using SimpleToDoManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoManager.UI
{
    public class Menu
    {
        private const int MENUITEMS = 5;
        private readonly IToDoService _service;
        public Menu(IToDoService service)
        {
            _service = service;

        }
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Show();
                switch (Select())
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        View();
                        Console.WriteLine($"Press any key to go back...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Mark();
                        break;
                    case 4:
                        Delete();
                        break;
                    default:
                        exit = true;
                        break;
                }
            }
            return;
        }
        private void Show()
        {
            Console.ResetColor();
            Console.WriteLine("---- To-Do List ----");
            Console.WriteLine("1. Add Task\n2. View Tasks\n3. Mark Completed\n4. Delete task\n5. Exit");
        }
        private int Select()
        {
            int choice = -1;
            while (choice < 0)
            {
                Console.Write("Select an option: ");
                var temp = Console.ReadLine();
                try
                {
                    choice = Convert.ToInt32(temp);
                    if (choice < 1 || choice > MENUITEMS) choice = -1;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{e.Message}");
                    Console.ResetColor();
                }
            }
            return choice;
        }

        private void Add()
        {
            Console.Clear();
            Console.WriteLine("Write the task you want added:");
            Console.WriteLine("(Type \"0\" to go back)");
            string? input = string.Empty;
            while (string.IsNullOrEmpty(input))
            {
                input = Console.ReadLine();
            }
            if (input.Equals("0")) return;
            var result = _service.Add(input);
            if (result != null)
                Console.WriteLine("Task added successfully!");
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was an error while adding the task.");
                Console.ResetColor();
            }
            return;
        }
        private void View()
        {
            Console.Clear();
            Console.WriteLine("--- Current tasks ---");
            _service.GetAll();
            return;
        }

        private void Mark()
        {
            View();
            int index = PromptForIndex("Type the index of the task you want completed:");
            if (index == 0) return;
            var marked = _service.MarkCompleted(index - 1);
            if (marked == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was an error while marking the task");
                Console.ResetColor();
                return;
            }
            View();
            return;
        }

        private void Delete()
        {
            View();
            int index = PromptForIndex("Type the index of the task you want deleted:");
            if (index == 0) return;
            var deleted = _service.Delete(index - 1);
            if (deleted == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was an error while deleting task");
                Console.ResetColor();
                return;
            }
            View();
            Console.WriteLine($"Task #{index} \"{deleted.Name}\" sucessfully deleted.");
            return;
        }

        private int PromptForIndex(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("(Type \"0\" to go back)");
            int input = -1;
            while (input < 0)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input < 0) Console.WriteLine("Pick a valid number:");
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{e.Message}");
                    Console.ResetColor();
                }
            }
            return input;
        }
    }
}

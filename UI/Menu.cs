using SimpleToDoManager.Interfaces;
using SimpleToDoManager.Models;

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
                ShowOptions();
                switch (Select())
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        View(true);      
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
        private void ShowOptions()
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
            while (string.IsNullOrWhiteSpace(input))
            {
                input = Console.ReadLine();
            }
            if (input.Equals("0")) return;
            var result =  _service.Add(input);
            if (result != null)
                Console.WriteLine("\nTask added successfully!");
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was an error while adding the task.");
                Console.ResetColor();
            }
            WaitForKey();
            return;
        }

        private List<ToDoItem> View(bool pause)
        {
            Console.Clear();
            Console.WriteLine("--- Current tasks ---");
            var itemList = _service.GetAll();
            for(int i = 0; i < itemList.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                if (itemList[i].IsCompleted)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("✓ ");
                }
                Console.WriteLine($"{itemList[i].Name}");
                Console.ResetColor();
            }
            if (pause)
            {
                WaitForKey();
            }
            return itemList;
        }

        private void Mark()
        {
            var itemList = View(false);
            int index = PromptForIndex("\nType the index of the task you want completed:");
            if (index == 0) return;
            var item = itemList.ElementAtOrDefault(index-1);
            if (item == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid task index!");
                Console.ResetColor();
                WaitForKey();
                return;
            }
            var marked = _service.MarkCompleted(item.Id);
            if (marked == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was an error while marking the task");
                Console.ResetColor();
                WaitForKey();
                return;
            }
            View(true);
            return;
        }

        private void Delete()
        {
            var itemList = View(false);
            int index = PromptForIndex("\nType the index of the task you want deleted:");
            if (index == 0) return;
            var item = itemList.ElementAtOrDefault(index-1);
            if (item == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid task index!");
                Console.ResetColor();
                WaitForKey();
                return;
            }
            var deleted = _service.Delete(item.Id);
            if (deleted == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was an error while deleting task");
                Console.ResetColor();
                WaitForKey();
                return;
            }
            View(false);
            Console.WriteLine($"\nTask #{index} \"{deleted.Name}\" sucessfully deleted.");
            WaitForKey();
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

        private void WaitForKey()
        {
            Console.WriteLine($"\nPress any key to go back...");
            Console.ReadKey();
        }
    }
}

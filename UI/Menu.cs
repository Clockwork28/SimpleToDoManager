using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoManager.UI
{
    public static class Menu
    {
        public static void Run()
        {
            Console.Clear();
            Show();
            switch (Select())
            {
                case 1:
                    // Add task
                    break;
                case 2:
                    // View tasks
                    break;
                case 3:
                    // Mark completed
                    break;
                case 4:
                    // Delete task
                    break;
                default:
                    return;
            }
        }
        private static void Show()
        {
            Console.ResetColor();
            Console.WriteLine("---- To-Do List ----");
            Console.WriteLine("1. Add Task\n2. View Tasks\n3. Mark Completed\n4. Delete task\n5. Exit");
        }
        private static int Select()
        {
            int choice = -1;
            while (choice < 0)
            {
                Console.Write("Select an option: ");
                var temp = Console.ReadLine();
                try
                {
                    choice = Convert.ToInt32(temp);
                    if (choice < 1 || choice > 4) choice = -1;
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
    }
}

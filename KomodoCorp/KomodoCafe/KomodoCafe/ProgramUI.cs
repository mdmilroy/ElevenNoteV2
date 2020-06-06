using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class ProgramUI
    {
        public void Run()
        {
            UserHelper _helper = new UserHelper();
            MenuRepo _menu = new MenuRepo();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(
                    "Welcome to the Menu Management System.\n" +
                    "Please choose an option below:");
                Console.WriteLine(
                    "1. Create a menu item.\n" +
                    "2. Delete a menu item.\n" +
                    "3. View a list of all menu items.\n" +
                    "4. Exit.\n");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        Menu newItem = _helper.GetNewItemToAdd(_menu.menu);
                        _menu.CreateMenuItem(newItem);
                        Console.Clear();
                        Console.WriteLine("Your item has been added to the menu.\n" +
                            "Press any key to return to the main menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        if (_menu.menu.Count > 0)
                        {
                            Menu itemToRemove = _helper.GetItemToRemove(_menu.menu);
                            _menu.DeleteMenuItem(itemToRemove);
                            Console.WriteLine("Your item has been removed from the menu.\n" +
                                "Press any key to return to the main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("There are currently no menu items to view.\n" +
                                "Press any key to return to the main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "3":
                        if (_menu.menu.Count > 0)
                        {
                            List<Menu> repoToView = _helper.GetItemsToView(_menu);
                            _menu.ViewAllMenuItems(repoToView);
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("There are currently no menu items to view.\n" +
                                "Press any key to return to the main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "4":
                        isRunning = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
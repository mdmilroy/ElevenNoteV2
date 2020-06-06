using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class UserHelper
    {
        public Menu GetNewItemToAdd(List<Menu> menu)
        {
            int num = menu.Count + 1;
            Console.WriteLine("What is the name of the item you wish to add?");
            string name = Console.ReadLine();

            Console.WriteLine("\nBriefly describe the menu item: ");
            string desc = Console.ReadLine();

            Console.WriteLine("\nPlease enter the list of ingredients:");
            string ingred = Console.ReadLine();

            bool priceInt = false;
            double cost = 0;
            while (!priceInt)
            {
                Console.WriteLine("\nWhat is the price for this item?");
                string response = Console.ReadLine();
                if (double.TryParse(response, out cost))
                {
                    cost = Convert.ToDouble(response);
                    priceInt = true;
                }
                else
                {
                    Console.WriteLine("\nPlease enter a dollar amount.");
                }
            }

            Menu newItem = new Menu(num, name, desc, ingred, cost);
            return newItem;
        }

        public Menu GetItemToRemove(List<Menu> menu)
        {
            Console.WriteLine("Which item would you like to remove?\n");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"Number {menu[i].mealNumber}: {menu[i].mealName} \n");
            }
            int r = Convert.ToInt32(Console.ReadLine());

            Menu itemToRemove = new Menu();
            itemToRemove.mealNumber = r;

            return itemToRemove;
        }

        public List<Menu> GetItemsToView(MenuRepo menu)
        {
            return menu.menu;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class Menu
    {
        public int mealNumber;
        public string mealName;
        public string description;
        public string ingredients;
        public double price;

        public Menu(int num, string name, string descr, string ingred, double cost)
        {
            mealNumber = num;
            mealName = name;
            description = descr;
            ingredients = ingred;
            price = cost;
        }

        public Menu()
        {
        
        }

    }
}

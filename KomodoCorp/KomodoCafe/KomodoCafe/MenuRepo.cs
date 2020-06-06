using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuRepo
    {
        public List<Menu> menu = new List<Menu>();
        public void CreateMenuItem(Menu item)
        {
            menu.Add(item);
        }
        public List<Menu> ViewAllMenuItems(List<Menu> repoToView)
        {
            Console.WriteLine("{0, -10} {1, -15}", "Item #", "Description");
            foreach (Menu item in repoToView)
            {
                Console.WriteLine("{0, -10} {1, -15}", item.mealNumber, item.mealName);
            }
            return repoToView;
        }

        public void DeleteMenuItem(Menu itemToRemove)
        {
            menu.RemoveAll(x => x.mealNumber == itemToRemove.mealNumber);
        }
    }
}

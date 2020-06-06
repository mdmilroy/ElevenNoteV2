using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    class ProgramUI
    {
        public void Run()
        {
            OutingsRepo repo = new OutingsRepo();
            bool running = true;
            UserHelper helper = new UserHelper();

            while (running)
            {
                int response = new int();

                Console.WriteLine("What would you like to do? \n" +
                    "1. Add an outing \n" +
                    "2. View total costs of a certain outing type \n" +
                    "3. Exit");
                try
                {
                    response = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please select an option provided.");
                }

                switch (response)
                {
                    case 1:
                        var add = helper.GetOutingToAdd();
                        repo.AddOuting(add);
                        break;
                    case 2:
                        var type = helper.GetTypeForCost();
                        repo.TotalCostByType(type);
                        break;
                    case 3:
                        running = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            }
        }
    }
}

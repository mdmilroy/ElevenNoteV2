using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    class UserHelper
    {
        public Outings GetOutingToAdd()
        {
            TypeOfEvent what = TypeOfEvent.Unknown;
            int guests = -1;
            DateTime date = new DateTime();
            double individual = -1;
            double total = -1;

            while (what == TypeOfEvent.Unknown)
            {
                Console.WriteLine("What type of event are you adding?\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert");
                string t = Console.ReadLine();
                switch (t)
                {
                    case "1":
                        what = TypeOfEvent.Golf;
                        break;
                    case "2":
                        what = TypeOfEvent.Bowling;
                        break;
                    case "3":
                        what = TypeOfEvent.AmusementPark;
                        break;
                    case "4":
                        what = TypeOfEvent.Concert;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            }

            while (guests == -1)
            {
                Console.WriteLine("How many attendees were there?");
                string a = Console.ReadLine();
                try 
                { 
                   guests = Convert.ToInt32(a);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a valid number of individuals.");
                }
            }

            while (date == new DateTime())
            {
                Console.WriteLine("When did the event take place? (YYYY, MM, DD)");
                string d = Console.ReadLine();
                try
                {
                    date = Convert.ToDateTime(d);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a date in the given format.");
                }
            }

            while (individual == -1)
            {
                Console.WriteLine("What was the cost of an individual ticket?");
                try
                {
                    individual = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            total = guests * individual;

            Outings outing = new Outings(what, guests, date, individual, total);
            Console.WriteLine($"Event: {what.ToString()} \n" +
                $"Guests: {guests} \n" +
                $"Date: {date.ToShortDateString()} \n" +
                $"Ticket Cost: ${individual} \n" +
                $"Total Cost: ${total}");
            Console.ReadLine();
            return outing;

        }
        public TypeOfEvent GetTypeForCost()
        {
            TypeOfEvent what = TypeOfEvent.Unknown;
            int t = 0;

            Console.WriteLine("What type of event would you like the total cost for?\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            try
            {
                t = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                    Console.WriteLine("Please select a valid option.");
            }
            switch (t)
            {
                case 1:
                    what = TypeOfEvent.Golf;
                    break;
                case 2:
                    what = TypeOfEvent.Bowling;
                    break;
                case 3:
                    what = TypeOfEvent.AmusementPark;
                    break;
                case 4:
                    what = TypeOfEvent.Concert;
                    break;
                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }

            return what;
        }
    }
}

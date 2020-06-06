using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    public class OutingsRepo
    {
        private List<Outings> allOutings = new List<Outings>();

        public void AddOuting(Outings outing)
        {
            allOutings.Add(outing);
        }

        public List<Outings> ListAllOutings()
        {
            Console.WriteLine("{0} {1, -10} {2, -10}", "Date of Event", "Event Type", "# of Attendees");
            foreach (Outings outing in allOutings)
            {
                Console.WriteLine("{0} {1, -10} {2, -10}", outing.dateOfEvent, outing.OutingType, outing.attendees);
            }
            return allOutings;
        }

        public double TotalOutingsCost()
        {
            double totalCost = 0;
            foreach (Outings outing in allOutings)
            {
                totalCost += outing.costTotal;
            }
            Console.WriteLine($"${totalCost.ToString()}");
            return totalCost;
        }

        public double TotalCostByType(TypeOfEvent whatType)
        {
            double totalTypeCost = 0;
            foreach (Outings outing in allOutings)
            {
                if (outing.OutingType == whatType)
                {
                    totalTypeCost += outing.costTotal;
                }
            }
            Console.WriteLine($"${totalTypeCost.ToString()}");
            return totalTypeCost;
        }
    }
}

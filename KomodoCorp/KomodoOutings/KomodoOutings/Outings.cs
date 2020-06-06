using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    public enum TypeOfEvent
    {
        Unknown, Golf, Bowling, AmusementPark, Concert
    }

    public class Outings
    {

        public TypeOfEvent OutingType { get; private set; }
        public int attendees { get; private set; }
        public DateTime dateOfEvent { get; private set; }
        public double costIndividual { get; private set; }
        public double costTotal { get; private set; }

        public Outings(TypeOfEvent what, int guests, DateTime date, double individual, double total)
        {
            OutingType = what;
            attendees = guests;
            dateOfEvent = date;
            costIndividual = individual;
            costTotal = total;
        }
    }


}

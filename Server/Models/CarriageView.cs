using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class CarriageView
    {
        public double price;
        public int carriageNumber;
        public string carriageType;
        public int? freeSeats;

        public CarriageView(CarriageHasLocomotive element, int destination)
        {
            carriageNumber = element.Carriage.Number;
            carriageType = element.Carriage.CarriageType.Name;
            price = element.Carriage.CarriageType.Pricefactor * destination;
            freeSeats = element.FreeSeats;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Locomotive
    {
        public Locomotive()
        {
            CarriageHasLocomotive = new HashSet<CarriageHasLocomotive>();
            Trip = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public double PricePerKilometer { get; set; }

        public ICollection<CarriageHasLocomotive> CarriageHasLocomotive { get; set; }
        public ICollection<Trip> Trip { get; set; }
    }
}

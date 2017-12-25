using System;
using System.Collections.Generic;

namespace Server
{
    public partial class CarriageHasLocomotive
    {
        public int Id { get; set; }
        public int CarriageId { get; set; }
        public int LocomotiveId { get; set; }
        public int? FreeSeats { get; set; }

        public Carriage Carriage { get; set; }
        public Locomotive Locomotive { get; set; }
    }
}

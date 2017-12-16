using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Traincompositioncarriage
    {
        public int Id { get; set; }
        public int? BookSeats { get; set; }
        public int CarriageId { get; set; }
        public int TripId { get; set; }
    }
}

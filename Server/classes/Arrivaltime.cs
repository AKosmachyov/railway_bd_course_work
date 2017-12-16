using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Arrivaltime
    {
        public int Id { get; set; }
        public DateTimeOffset ArriveTime { get; set; }
        public int TripId { get; set; }
        public int PointId { get; set; }
    }
}

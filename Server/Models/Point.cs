using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Point
    {
        public Point()
        {
            Arrivaltime = new HashSet<Arrivaltime>();
        }

        public int Id { get; set; }
        public int StayTime { get; set; }
        public int TripDistance { get; set; }
        public int RouteId { get; set; }
        public int StationId { get; set; }

        public Route Route { get; set; }
        public Station Station { get; set; }
        public ICollection<Arrivaltime> Arrivaltime { get; set; }
    }
}

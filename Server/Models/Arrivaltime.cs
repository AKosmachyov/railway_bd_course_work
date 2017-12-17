using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Arrivaltime
    {
        public Arrivaltime()
        {
            TicketArriveNavigation = new HashSet<Ticket>();
            TicketDepartNavigation = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public DateTimeOffset ArriveTime { get; set; }
        public int PointId { get; set; }
        public int TripId { get; set; }

        public Point Point { get; set; }
        public Trip Trip { get; set; }
        public ICollection<Ticket> TicketArriveNavigation { get; set; }
        public ICollection<Ticket> TicketDepartNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int CarriageNumber { get; set; }
        public int Depart { get; set; }
        public int Arrive { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}

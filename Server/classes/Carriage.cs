using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Carriage
    {
        public int Id { get; set; }
        public int CarriageTypeId { get; set; }
        public int Number { get; set; }
        public int Seats { get; set; }

        public Carriagetype CarriageType { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Trip
    {
        public int Id { get; set; }
        public int LocomotiveId { get; set; }

        public Locomotive Locomotive { get; set; }
    }
}

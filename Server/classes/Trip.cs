using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Trip
    {
        public Trip()
        {
            Arrivaltime = new HashSet<Arrivaltime>();
            Traincompositioncarriage = new HashSet<Traincompositioncarriage>();
        }

        public int Id { get; set; }
        public int LocomotiveId { get; set; }

        public Locomotive Locomotive { get; set; }
        public ICollection<Arrivaltime> Arrivaltime { get; set; }
        public ICollection<Traincompositioncarriage> Traincompositioncarriage { get; set; }
    }
}

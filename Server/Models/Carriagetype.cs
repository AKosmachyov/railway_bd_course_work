using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Carriagetype
    {
        public Carriagetype()
        {
            Carriage = new HashSet<Carriage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Pricefactor { get; set; }

        public ICollection<Carriage> Carriage { get; set; }
    }
}

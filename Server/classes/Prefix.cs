using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Prefix
    {
        public Prefix()
        {
            Station = new HashSet<Station>();
        }

        public int Id { get; set; }
        public string Value { get; set; }

        public ICollection<Station> Station { get; set; }
    }
}

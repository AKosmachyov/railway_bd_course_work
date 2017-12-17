using System;
using System.Collections.Generic;

namespace Server
{
    public partial class City
    {
        public City()
        {
            Station = new HashSet<Station>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public Region Region { get; set; }
        public ICollection<Station> Station { get; set; }
    }
}

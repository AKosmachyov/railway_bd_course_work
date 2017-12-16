using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Station
    {
        public Station()
        {
            Point = new HashSet<Point>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PrefixId { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public Prefix Prefix { get; set; }
        public ICollection<Point> Point { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Route
    {
        public Route()
        {
            Point = new HashSet<Point>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Point> Point { get; set; }
    }
}

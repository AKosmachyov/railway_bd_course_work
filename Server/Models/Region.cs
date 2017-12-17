using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Region
    {
        public Region()
        {
            City = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<City> City { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Server
{
    public partial class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PrefixId { get; set; }
        public int CityId { get; set; }

        public Prefix Prefix { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Server
{
    public partial class User
    {
        public User()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassportSerial { get; set; }

        public ICollection<Ticket> Ticket { get; set; }
    }
}

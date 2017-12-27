using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class TicketViewModel
    {
        public int orderNumber;
        public string fio;
        public string passportSeria;

        public string fromStation;
        public DateTimeOffset fromDate;

        public string toStation;
        public DateTimeOffset toDate;

        public string carriage;
        public double price;

        public TicketViewModel()
        {
        }
    }
}

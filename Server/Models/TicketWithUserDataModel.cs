using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class TicketWithUserDataModel
    {
        public List<CarriageView> carriagesView;
        public string fromStation;
        public string toStation;
        public DateTimeOffset fromDate;
        public DateTimeOffset toDate;

        public TicketWithUserDataModel()
        {
        }
    }
}

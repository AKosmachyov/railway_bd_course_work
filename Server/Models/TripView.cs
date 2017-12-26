using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class TripView
    {
        public DateTimeOffset fromDate;
        public DateTimeOffset toDate;
        public string fromStation;
        public string toStation;
        public string routeName;

        public int tripID;
        public int fromID;
        public int toID;

        public TripView(Arrivaltime from, Point to, prod_dbContext _context)
        {
            fromDate = from.ArriveTime;
            _context.Point
                .Include(p => p.Route)
                .Include(p => p.Station)
                .Where(p => p.Id == from.PointId)
                .First();

            fromStation = from.Point.Station.Name;
            toStation = to.Station.Name;

            routeName = from.Point.Route.Name;

            var arrivalTimeTo = _context.Arrivaltime
                .Where(ar => ar.PointId == to.Id && ar.TripId == from.TripId).First();
            toDate = arrivalTimeTo.ArriveTime;

            var locomotivID = from.Trip.LocomotiveId;
            var carriagesHasLocomotives = _context.CarriageHasLocomotive
                .Include(c => c.Carriage)
                .Where(c => c.LocomotiveId == locomotivID);

            tripID = from.TripId;
            fromID = from.Id;
            toID = arrivalTimeTo.Id;
        }
    }
}

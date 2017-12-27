using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly prod_dbContext _context;

        public HomeController(prod_dbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Quick(string station)
{
       station = station.ToLower().Trim();

    IEnumerable<string> matched = _context.Station.Where(x=>x.Name.IndexOf(station, StringComparison.OrdinalIgnoreCase) >= 0).Select(x=>x.Name);
    return Ok(matched);
}

        public async Task<IActionResult> Search(string from, string to, DateTime date, string sortOrder)
        {
            DateTime endDate = date.AddDays(1);
    ViewBag.From = from;
    ViewBag.To = to;
    ViewBag.Date = date;
    ViewBag.FromSortParm = String.IsNullOrEmpty(sortOrder) ? "from_desc" : "";
    ViewBag.ToSortParm = sortOrder == "To" ? "to_desc" : "To";
    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var arrivalTimes = _context.Arrivaltime
                .Include(ar => ar.Trip)
                .Include(ar => ar.Point)
                .Where(ar => ar.ArriveTime >= date && ar.ArriveTime < endDate && ar.Point.Station.Name == from);

            List<int> routesID = new List<int>();
            foreach (var item in arrivalTimes)
            {
                routesID.Add(item.Point.RouteId);
            }

            var toPoints = _context.Point
                .Include(p => p.Station)
                .Where(p => p.Station.Name == to && routesID.Contains(p.RouteId));

            var res = new List<TripView>();

            foreach (var itemTo in toPoints)
            {
                foreach (var itemFrom in arrivalTimes)
                {
                    if (itemTo.RouteId == itemFrom.Point.RouteId && itemTo.TripDistance > itemFrom.Point.TripDistance)
                    {
                        res.Add(new TripView(itemFrom, itemTo, _context));
                    }
                }
            }

            switch (sortOrder)
    {
        case "from_desc":
            res = res.OrderByDescending(x=>x.fromDate).ToList();
            break;
        case "Date":
            res = res.OrderBy(x=>x.routeName).ToList();
            break;
        case "date_desc":
            res = res.OrderByDescending(x=>x.routeName).ToList();
            break;
        case "To":
        res = res.OrderBy(x=>x.toDate).ToList();
        break;
        case "to_desc":
        res = res.OrderByDescending(x=>x.toDate).ToList();
        break;
        default:
            res = res.OrderBy(s => s.fromDate).ToList();
            break;
    }
            

            return View(res);
        }

        public async Task<IActionResult> TripDetail(int? tripID, int? fromID, int? toID)
        {
            if (tripID == null || fromID == null || toID == null)
                return NotFound();

            var from = _context.Arrivaltime
                .Include(ar => ar.Point)
                .Include(ar => ar.Trip)
                .First(ar => ar.TripId == tripID && ar.Id == fromID);
            var to = _context.Arrivaltime
                .Include(ar => ar.Point)
                .First(ar => ar.TripId == tripID && ar.Id == toID);

            if (from == null || to == null)
                return NotFound();

            if (from.Point.TripDistance > to.Point.TripDistance) {
                return NotFound();
            }

            var destination = to.Point.TripDistance - from.Point.TripDistance;

            var locomotiveID = from.Trip.LocomotiveId;
            var carriageHasLocomotiveArr = _context.CarriageHasLocomotive
                .Include(cr => cr.Locomotive)
                .Include(cr => cr.Carriage.CarriageType)
                .Where(cr => cr.CarriageId == locomotiveID);


            var fromStation = from.Point.Station.Name;
            var toStation = to.Point.Station.Name;
            var fromTime = from.ArriveTime;
            var toTime = to.ArriveTime;

            var res = new List<CarriageView>();
            foreach (var item in carriageHasLocomotiveArr)
            {
                res.Add(new CarriageView(item, destination));
            }
            return View(res);
        }
         public IActionResult Ticket(int? tripID, int? fromID, int? toID, int? carriage)
        {
            if (tripID == null || fromID == null || toID == null || carriage == null)
                return NotFound();

            var from = _context.Arrivaltime
                .Include(ar => ar.Point)
                .Include(ar => ar.Trip)
                .First(ar => ar.TripId == tripID && ar.Id == fromID);
            var to = _context.Arrivaltime
                .Include(ar => ar.Point)
                .First(ar => ar.TripId == tripID && ar.Id == toID);

            if (from == null || to == null)
                return NotFound();

            if (from.Point.TripDistance > to.Point.TripDistance) {
                return NotFound();
            }

            var carriageHasLocomotive = _context.CarriageHasLocomotive
                .Include(cl => cl.Carriage)
                .First(cl => cl.Id == carriage);

            if (carriageHasLocomotive == null) {
                return NotFound();
            }

            var destination = to.Point.TripDistance - from.Point.TripDistance;


            // var str = HostingEnvironment.MapPath(@"~/App_Data/ticket.html");

            // StringBuilder sb = new StringBuilder();
            // sb.Append(File.ReadAllText(str));
            // sb.Replace("{orderNumber}", ticket.id.ToString());
            // var arr = ticket.tripDirection.Split(',');
            // var tempStr = String.Format("{0} {1}—{2}", arr[0], arr[1], arr[2]);
            // sb.Replace("{direction}", tempStr);

            // sb.Replace("{fio}", ticket.userName);
            // sb.Replace("{doc}", ticket.docId);

            // tempStr = String.Format("{0} {1}", ticket.fromStation.name, ticket.fromDepart.ToString("g"));
            // sb.Replace("{from}", tempStr);
            // tempStr = String.Format("{0} {1}", ticket.toStation.name, ticket.toArrive.ToString("g"));
            // sb.Replace("{to}", tempStr);

            // tempStr = String.Format("{0} {1}", ticket.carriage, ticket.carriageType);
            // sb.Replace("{carriage}", tempStr);

            // Byte[] res = null;
            // using (MemoryStream ms = new MemoryStream())
            // {
            //     var pdf = PdfGenerator.GeneratePdf(sb.ToString(), PdfSharp.PageSize.Letter);
            //     pdf.Save(ms);
            //     res = ms.ToArray();
            // }
            // return res;

            // return View();
        }
    }
}

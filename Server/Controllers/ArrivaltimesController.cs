using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server;

namespace Server.Controllers
{
    public class ArrivaltimesController : Controller
    {
        private readonly prod_dbContext _context;

        public ArrivaltimesController(prod_dbContext context)
        {
            _context = context;
        }

        // GET: Arrivaltimes
        public async Task<IActionResult> Index()
        {
            var prod_dbContext = _context.Arrivaltime.Include(a => a.Point.Station).Include(a => a.Trip).Include(a => a.Point.Route);
            return View(await prod_dbContext.ToListAsync());
        }

        // GET: Arrivaltimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivaltime = await _context.Arrivaltime
                .Include(a => a.Point.Station)
                .Include(a => a.Trip)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (arrivaltime == null)
            {
                return NotFound();
            }

            return View(arrivaltime);
        }

        // GET: Arrivaltimes/Create
        public IActionResult Create()
        {
            ViewData["PointId"] = new SelectList(_context.Point, "Id", "Id");
            ViewData["TripId"] = new SelectList(_context.Trip, "Id", "Id");
            return View();
        }

        // POST: Arrivaltimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArriveTime,PointId,TripId")] Arrivaltime arrivaltime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arrivaltime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PointId"] = new SelectList(_context.Point, "Id", "Id", arrivaltime.PointId);
            ViewData["TripId"] = new SelectList(_context.Trip, "Id", "Id", arrivaltime.TripId);
            return View(arrivaltime);
        }

        // GET: Arrivaltimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivaltime = await _context.Arrivaltime.Include(x => x.Point.Station).SingleOrDefaultAsync(m => m.Id == id);
            if (arrivaltime == null)
            {
                return NotFound();
            }
            List<object> newList = new List<object>();
            var station = _context.Point.Include(x => x.Station).Include(x => x.Route);
            foreach (var member in station)
                newList.Add(new
                {
                    Id = member.Id,
                    Name = member.Route.Name + ", " + member.Station.Name
                });
            ViewData["PointId"] = new SelectList(newList, "Id", "Name", arrivaltime.PointId);
            ViewData["TripId"] = new SelectList(_context.Trip, "Id", "Id", arrivaltime.TripId);
            return View(arrivaltime);
        }

        // POST: Arrivaltimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArriveTime,PointId,TripId")] Arrivaltime arrivaltime)
        {
            if (id != arrivaltime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arrivaltime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArrivaltimeExists(arrivaltime.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PointId"] = new SelectList(_context.Point, "Id", "Id", arrivaltime.PointId);
            ViewData["TripId"] = new SelectList(_context.Trip, "Id", "Id", arrivaltime.TripId);
            return View(arrivaltime);
        }

        // GET: Arrivaltimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivaltime = await _context.Arrivaltime
                .Include(a => a.Point)
                .Include(a => a.Trip)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (arrivaltime == null)
            {
                return NotFound();
            }

            return View(arrivaltime);
        }

        // POST: Arrivaltimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arrivaltime = await _context.Arrivaltime.SingleOrDefaultAsync(m => m.Id == id);
            _context.Arrivaltime.Remove(arrivaltime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArrivaltimeExists(int id)
        {
            return _context.Arrivaltime.Any(e => e.Id == id);
        }
    }
}

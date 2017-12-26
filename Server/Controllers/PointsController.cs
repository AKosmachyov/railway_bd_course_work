using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server;

namespace Server.Controllers
{
    public class PointsController : Controller
    {
        private readonly prod_dbContext _context;

        public PointsController(prod_dbContext context)
        {
            _context = context;
        }

        // GET: Points
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Index()
        {
            var prod_dbContext = _context.Point.Include(p => p.Route).Include(p => p.Station);
            return View(await prod_dbContext.ToListAsync());
        }

        // GET: Points/Details/5
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var point = await _context.Point
                .Include(p => p.Route)
                .Include(p => p.Station)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (point == null)
            {
                return NotFound();
            }

            return View(point);
        }

        // GET: Points/Create
        [Authorize (Roles="admin")]
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Name");
            ViewData["StationId"] = new SelectList(_context.Station, "Id", "Name");
            return View();
        }

        // POST: Points/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Create([Bind("Id,StayTime,TripDistance,RouteId,StationId")] Point point)
        {
            if (ModelState.IsValid)
            {
                _context.Add(point);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Name", point.RouteId);
            ViewData["StationId"] = new SelectList(_context.Station, "Id", "Name", point.StationId);
            return View(point);
        }

        // GET: Points/Edit/5
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var point = await _context.Point.SingleOrDefaultAsync(m => m.Id == id);
            if (point == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Name", point.RouteId);
            ViewData["StationId"] = new SelectList(_context.Station, "Id", "Name", point.StationId);
            return View(point);
        }

        // POST: Points/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StayTime,TripDistance,RouteId,StationId")] Point point)
        {
            if (id != point.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(point);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointExists(point.Id))
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
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Name", point.RouteId);
            ViewData["StationId"] = new SelectList(_context.Station, "Id", "Name", point.StationId);
            return View(point);
        }

        // GET: Points/Delete/5
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var point = await _context.Point
                .Include(p => p.Route)
                .Include(p => p.Station)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (point == null)
            {
                return NotFound();
            }

            return View(point);
        }

        // POST: Points/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var point = await _context.Point.SingleOrDefaultAsync(m => m.Id == id);
            _context.Point.Remove(point);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointExists(int id)
        {
            return _context.Point.Any(e => e.Id == id);
        }
    }
}

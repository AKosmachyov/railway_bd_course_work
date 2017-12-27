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
    public class TripsController : Controller
    {
        private readonly prod_dbContext _context;

        public TripsController(prod_dbContext context)
        {
            _context = context;
        }

        // GET: Trips
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Index()
        {
            var prod_dbContext = _context.Trip.Include(t => t.Locomotive);
            return View(await prod_dbContext.ToListAsync());
        }

        // GET: Trips/Details/5
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .Include(t => t.Locomotive)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        [Authorize (Roles="Admin")]
        public IActionResult Create()
        {
            ViewData["LocomotiveId"] = new SelectList(_context.Locomotive, "Id", "Id");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Create([Bind("Id,LocomotiveId")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocomotiveId"] = new SelectList(_context.Locomotive, "Id", "Id", trip.LocomotiveId);
            return View(trip);
        }

        // GET: Trips/Edit/5
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.SingleOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["LocomotiveId"] = new SelectList(_context.Locomotive, "Id", "Id", trip.LocomotiveId);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocomotiveId")] Trip trip)
        {
            if (id != trip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.Id))
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
            ViewData["LocomotiveId"] = new SelectList(_context.Locomotive, "Id", "Id", trip.LocomotiveId);
            return View(trip);
        }

        // GET: Trips/Delete/5
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .Include(t => t.Locomotive)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trip.SingleOrDefaultAsync(m => m.Id == id);
            _context.Trip.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trip.Any(e => e.Id == id);
        }
    }
}

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
    public class TraincompositioncarriagesController : Controller
    {
        private readonly prod_dbContext _context;

        public TraincompositioncarriagesController(prod_dbContext context)
        {
            _context = context;
        }

        // GET: Traincompositioncarriages
        public async Task<IActionResult> Index()
        {
            var prod_dbContext = _context.Traincompositioncarriage.Include(t => t.Carriage).Include(t => t.Trip);
            return View(await prod_dbContext.ToListAsync());
        }

        // GET: Traincompositioncarriages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traincompositioncarriage = await _context.Traincompositioncarriage
                .Include(t => t.Carriage)
                .Include(t => t.Trip)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (traincompositioncarriage == null)
            {
                return NotFound();
            }

            return View(traincompositioncarriage);
        }

        // GET: Traincompositioncarriages/Create
        public IActionResult Create()
        {
            ViewData["CarriageId"] = new SelectList(_context.Carriage, "Id", "Id");
            ViewData["TripId"] = new SelectList(_context.Trip, "Id", "Id");
            return View();
        }

        // POST: Traincompositioncarriages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookSeats,CarriageId,TripId")] Traincompositioncarriage traincompositioncarriage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traincompositioncarriage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarriageId"] = new SelectList(_context.Carriage, "Id", "Id", traincompositioncarriage.CarriageId);
            ViewData["TripId"] = new SelectList(_context.Trip, "Id", "Id", traincompositioncarriage.TripId);
            return View(traincompositioncarriage);
        }

        // GET: Traincompositioncarriages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traincompositioncarriage = await _context.Traincompositioncarriage.SingleOrDefaultAsync(m => m.Id == id);
            if (traincompositioncarriage == null)
            {
                return NotFound();
            }
            ViewData["CarriageId"] = new SelectList(_context.Carriage, "Id", "Id", traincompositioncarriage.CarriageId);
            ViewData["TripId"] = new SelectList(_context.Trip, "Id", "Id", traincompositioncarriage.TripId);
            return View(traincompositioncarriage);
        }

        // POST: Traincompositioncarriages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookSeats,CarriageId,TripId")] Traincompositioncarriage traincompositioncarriage)
        {
            if (id != traincompositioncarriage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traincompositioncarriage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraincompositioncarriageExists(traincompositioncarriage.Id))
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
            ViewData["CarriageId"] = new SelectList(_context.Carriage, "Id", "Id", traincompositioncarriage.CarriageId);
            ViewData["TripId"] = new SelectList(_context.Trip, "Id", "Id", traincompositioncarriage.TripId);
            return View(traincompositioncarriage);
        }

        // GET: Traincompositioncarriages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traincompositioncarriage = await _context.Traincompositioncarriage
                .Include(t => t.Carriage)
                .Include(t => t.Trip)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (traincompositioncarriage == null)
            {
                return NotFound();
            }

            return View(traincompositioncarriage);
        }

        // POST: Traincompositioncarriages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traincompositioncarriage = await _context.Traincompositioncarriage.SingleOrDefaultAsync(m => m.Id == id);
            _context.Traincompositioncarriage.Remove(traincompositioncarriage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraincompositioncarriageExists(int id)
        {
            return _context.Traincompositioncarriage.Any(e => e.Id == id);
        }
    }
}

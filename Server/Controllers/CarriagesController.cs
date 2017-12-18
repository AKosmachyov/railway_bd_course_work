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
    public class CarriagesController : Controller
    {
        private readonly prod_dbContext _context;

        public CarriagesController(prod_dbContext context)
        {
            _context = context;
        }

        // GET: Carriages
        public async Task<IActionResult> Index()
        {
            var prod_dbContext = _context.Carriage.Include(c => c.CarriageType);
            return View(await prod_dbContext.ToListAsync());
        }

        // GET: Carriages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriage = await _context.Carriage
                .Include(c => c.CarriageType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carriage == null)
            {
                return NotFound();
            }

            return View(carriage);
        }

        // GET: Carriages/Create
        public IActionResult Create()
        {
            ViewData["CarriageTypeId"] = new SelectList(_context.Carriagetype, "Id", "Name");
            return View();
        }

        // POST: Carriages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarriageTypeId,Number,Seats")] Carriage carriage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carriage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarriageTypeId"] = new SelectList(_context.Carriagetype, "Id", "Name", carriage.CarriageTypeId);
            return View(carriage);
        }

        // GET: Carriages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriage = await _context.Carriage.SingleOrDefaultAsync(m => m.Id == id);
            if (carriage == null)
            {
                return NotFound();
            }
            ViewData["CarriageTypeId"] = new SelectList(_context.Carriagetype, "Id", "Name", carriage.CarriageTypeId);
            return View(carriage);
        }

        // POST: Carriages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarriageTypeId,Number,Seats")] Carriage carriage)
        {
            if (id != carriage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carriage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarriageExists(carriage.Id))
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
            ViewData["CarriageTypeId"] = new SelectList(_context.Carriagetype, "Id", "Name", carriage.CarriageTypeId);
            return View(carriage);
        }

        // GET: Carriages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriage = await _context.Carriage
                .Include(c => c.CarriageType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carriage == null)
            {
                return NotFound();
            }

            return View(carriage);
        }

        // POST: Carriages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carriage = await _context.Carriage.SingleOrDefaultAsync(m => m.Id == id);
            _context.Carriage.Remove(carriage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarriageExists(int id)
        {
            return _context.Carriage.Any(e => e.Id == id);
        }
    }
}

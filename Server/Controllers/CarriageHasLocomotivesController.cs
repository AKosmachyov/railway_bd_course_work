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
    public class CarriageHasLocomotivesController : Controller
    {
        private readonly prod_dbContext _context;

        public CarriageHasLocomotivesController(prod_dbContext context)
        {
            _context = context;
        }

        // GET: CarriageHasLocomotives
        public async Task<IActionResult> Index()
        {
            var prod_dbContext = _context.CarriageHasLocomotive.Include(c => c.Carriage).Include(c => c.Locomotive);
            return View(await prod_dbContext.ToListAsync());
        }

        // GET: CarriageHasLocomotives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriageHasLocomotive = await _context.CarriageHasLocomotive
                .Include(c => c.Carriage)
                .Include(c => c.Locomotive)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carriageHasLocomotive == null)
            {
                return NotFound();
            }

            return View(carriageHasLocomotive);
        }

        // GET: CarriageHasLocomotives/Create
        public IActionResult Create()
        {
            ViewData["CarriageId"] = new SelectList(_context.Carriage, "Id", "Id");
            ViewData["LocomotiveId"] = new SelectList(_context.Locomotive, "Id", "Id");
            return View();
        }

        // POST: CarriageHasLocomotives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarriageId,LocomotiveId,FreeSeats")] CarriageHasLocomotive carriageHasLocomotive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carriageHasLocomotive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarriageId"] = new SelectList(_context.Carriage, "Id", "Id", carriageHasLocomotive.CarriageId);
            ViewData["LocomotiveId"] = new SelectList(_context.Locomotive, "Id", "Id", carriageHasLocomotive.LocomotiveId);
            return View(carriageHasLocomotive);
        }

        // GET: CarriageHasLocomotives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriageHasLocomotive = await _context.CarriageHasLocomotive.SingleOrDefaultAsync(m => m.Id == id);
            if (carriageHasLocomotive == null)
            {
                return NotFound();
            }
            ViewData["CarriageId"] = new SelectList(_context.Carriage, "Id", "Id", carriageHasLocomotive.CarriageId);
            ViewData["LocomotiveId"] = new SelectList(_context.Locomotive, "Id", "Id", carriageHasLocomotive.LocomotiveId);
            return View(carriageHasLocomotive);
        }

        // POST: CarriageHasLocomotives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarriageId,LocomotiveId,FreeSeats")] CarriageHasLocomotive carriageHasLocomotive)
        {
            if (id != carriageHasLocomotive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carriageHasLocomotive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarriageHasLocomotiveExists(carriageHasLocomotive.Id))
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
            ViewData["CarriageId"] = new SelectList(_context.Carriage, "Id", "Id", carriageHasLocomotive.CarriageId);
            ViewData["LocomotiveId"] = new SelectList(_context.Locomotive, "Id", "Id", carriageHasLocomotive.LocomotiveId);
            return View(carriageHasLocomotive);
        }

        // GET: CarriageHasLocomotives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriageHasLocomotive = await _context.CarriageHasLocomotive
                .Include(c => c.Carriage)
                .Include(c => c.Locomotive)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carriageHasLocomotive == null)
            {
                return NotFound();
            }

            return View(carriageHasLocomotive);
        }

        // POST: CarriageHasLocomotives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carriageHasLocomotive = await _context.CarriageHasLocomotive.SingleOrDefaultAsync(m => m.Id == id);
            _context.CarriageHasLocomotive.Remove(carriageHasLocomotive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarriageHasLocomotiveExists(int id)
        {
            return _context.CarriageHasLocomotive.Any(e => e.Id == id);
        }
    }
}

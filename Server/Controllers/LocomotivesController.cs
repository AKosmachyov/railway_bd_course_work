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
    public class LocomotivesController : Controller
    {
        private readonly prod_dbContext _context;

        public LocomotivesController(prod_dbContext context)
        {
            _context = context;
        }

        // GET: Locomotives
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locomotive.ToListAsync());
        }

        // GET: Locomotives/Details/5
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locomotive = await _context.Locomotive
                .SingleOrDefaultAsync(m => m.Id == id);
            if (locomotive == null)
            {
                return NotFound();
            }

            return View(locomotive);
        }

        // GET: Locomotives/Create
        [Authorize (Roles="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locomotives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Create([Bind("Id,PricePerKilometer")] Locomotive locomotive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locomotive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locomotive);
        }

        // GET: Locomotives/Edit/5
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locomotive = await _context.Locomotive.SingleOrDefaultAsync(m => m.Id == id);
            if (locomotive == null)
            {
                return NotFound();
            }
            return View(locomotive);
        }

        // POST: Locomotives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PricePerKilometer")] Locomotive locomotive)
        {
            if (id != locomotive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locomotive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocomotiveExists(locomotive.Id))
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
            return View(locomotive);
        }

        // GET: Locomotives/Delete/5
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locomotive = await _context.Locomotive
                .SingleOrDefaultAsync(m => m.Id == id);
            if (locomotive == null)
            {
                return NotFound();
            }

            return View(locomotive);
        }

        // POST: Locomotives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locomotive = await _context.Locomotive.SingleOrDefaultAsync(m => m.Id == id);
            _context.Locomotive.Remove(locomotive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocomotiveExists(int id)
        {
            return _context.Locomotive.Any(e => e.Id == id);
        }
    }
}

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
    public class PrefixesController : Controller
    {
        private readonly prod_dbContext _context;
        
        public PrefixesController(prod_dbContext context)
        {
            _context = context;
        }

        // GET: Prefixes
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prefix.ToListAsync());
        }

        // GET: Prefixes/Details/5
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prefix = await _context.Prefix
                .SingleOrDefaultAsync(m => m.Id == id);
            if (prefix == null)
            {
                return NotFound();
            }

            return View(prefix);
        }

        // GET: Prefixes/Create
        [Authorize (Roles="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prefixes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Create([Bind("Id,Value")] Prefix prefix)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prefix);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prefix);
        }

        // GET: Prefixes/Edit/5
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prefix = await _context.Prefix.SingleOrDefaultAsync(m => m.Id == id);
            if (prefix == null)
            {
                return NotFound();
            }
            return View(prefix);
        }

        // POST: Prefixes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Value")] Prefix prefix)
        {
            if (id != prefix.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prefix);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrefixExists(prefix.Id))
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
            return View(prefix);
        }

        // GET: Prefixes/Delete/5
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prefix = await _context.Prefix
                .SingleOrDefaultAsync(m => m.Id == id);
            if (prefix == null)
            {
                return NotFound();
            }

            return View(prefix);
        }

        // POST: Prefixes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prefix = await _context.Prefix.SingleOrDefaultAsync(m => m.Id == id);
            _context.Prefix.Remove(prefix);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrefixExists(int id)
        {
            return _context.Prefix.Any(e => e.Id == id);
        }
    }
}

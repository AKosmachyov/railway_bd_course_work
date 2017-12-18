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
    public class CarriagetypesController : Controller
    {
        private readonly prod_dbContext _context;

        public CarriagetypesController(prod_dbContext context)
        {
            _context = context;
        }

        // GET: Carriagetypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carriagetype.ToListAsync());
        }

        // GET: Carriagetypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriagetype = await _context.Carriagetype
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carriagetype == null)
            {
                return NotFound();
            }

            return View(carriagetype);
        }

        // GET: Carriagetypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carriagetypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Pricefactor")] Carriagetype carriagetype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carriagetype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carriagetype);
        }

        // GET: Carriagetypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriagetype = await _context.Carriagetype.SingleOrDefaultAsync(m => m.Id == id);
            if (carriagetype == null)
            {
                return NotFound();
            }
            return View(carriagetype);
        }

        // POST: Carriagetypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Pricefactor")] Carriagetype carriagetype)
        {
            if (id != carriagetype.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carriagetype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarriagetypeExists(carriagetype.Id))
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
            return View(carriagetype);
        }

        // GET: Carriagetypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriagetype = await _context.Carriagetype
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carriagetype == null)
            {
                return NotFound();
            }

            return View(carriagetype);
        }

        // POST: Carriagetypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carriagetype = await _context.Carriagetype.SingleOrDefaultAsync(m => m.Id == id);
            _context.Carriagetype.Remove(carriagetype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarriagetypeExists(int id)
        {
            return _context.Carriagetype.Any(e => e.Id == id);
        }
    }
}

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
    public class TicketsController : Controller
    {
        private readonly prod_dbContext _context;

        public TicketsController(prod_dbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Index()
        {
            var prod_dbContext = _context.Ticket
                .Include(t => t.ArriveNavigation)
                .Include(t => t.DepartNavigation)
                .Include(t => t.User);
            return View(await prod_dbContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.ArriveNavigation)
                .Include(t => t.DepartNavigation)
                .Include(t => t.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        [Authorize (Roles="admin")]
        public IActionResult Create()
        {
            ViewData["Arrive"] = new SelectList(_context.Arrivaltime, "Id", "Id");
            ViewData["Depart"] = new SelectList(_context.Arrivaltime, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FirstName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Create([Bind("Id,Price,CarriageNumber,Depart,Arrive,UserId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Arrive"] = new SelectList(_context.Arrivaltime, "Id", "Id", ticket.Arrive);
            ViewData["Depart"] = new SelectList(_context.Arrivaltime, "Id", "Id", ticket.Depart);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FirstName", ticket.UserId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.SingleOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["Arrive"] = new SelectList(_context.Arrivaltime, "Id", "Id", ticket.Arrive);
            ViewData["Depart"] = new SelectList(_context.Arrivaltime, "Id", "Id", ticket.Depart);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FirstName", ticket.UserId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,CarriageNumber,Depart,Arrive,UserId")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            ViewData["Arrive"] = new SelectList(_context.Arrivaltime, "Id", "Id", ticket.Arrive);
            ViewData["Depart"] = new SelectList(_context.Arrivaltime, "Id", "Id", ticket.Depart);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FirstName", ticket.UserId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        [Authorize (Roles="admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.ArriveNavigation)
                .Include(t => t.DepartNavigation)
                .Include(t => t.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize (Roles="admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.SingleOrDefaultAsync(m => m.Id == id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musictify.Data;
using Musictify.Models;

namespace Musictify.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConcertTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConcertTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConcertTickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ConcertTickets.Include(c => c.Concert).Include(c => c.Tickets);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ConcertTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertTickets = await _context.ConcertTickets
                .Include(c => c.Concert)
                .Include(c => c.Tickets)
                .FirstOrDefaultAsync(m => m.ConcertTicketsID == id);
            if (concertTickets == null)
            {
                return NotFound();
            }

            return View(concertTickets);
        }

        // GET: ConcertTickets/Create
        public IActionResult Create()
        {
            ViewData["ConcertID"] = new SelectList(_context.Concert, "ConcertID", "ConcertID");
            ViewData["TicketsID"] = new SelectList(_context.Tickets, "TicketsID", "TicketsID");
            return View();
        }

        // POST: ConcertTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConcertTicketsID,ConcertID,TicketsID")] ConcertTickets concertTickets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concertTickets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConcertID"] = new SelectList(_context.Concert, "ConcertID", "ConcertID", concertTickets.ConcertID);
            ViewData["TicketsID"] = new SelectList(_context.Tickets, "TicketsID", "TicketsID", concertTickets.TicketsID);
            return View(concertTickets);
        }

        // GET: ConcertTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertTickets = await _context.ConcertTickets.FindAsync(id);
            if (concertTickets == null)
            {
                return NotFound();
            }
            ViewData["ConcertID"] = new SelectList(_context.Concert, "ConcertID", "ConcertID", concertTickets.ConcertID);
            ViewData["TicketsID"] = new SelectList(_context.Tickets, "TicketsID", "TicketsID", concertTickets.TicketsID);
            return View(concertTickets);
        }

        // POST: ConcertTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConcertTicketsID,ConcertID,TicketsID")] ConcertTickets concertTickets)
        {
            if (id != concertTickets.ConcertTicketsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concertTickets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcertTicketsExists(concertTickets.ConcertTicketsID))
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
            ViewData["ConcertID"] = new SelectList(_context.Concert, "ConcertID", "ConcertID", concertTickets.ConcertID);
            ViewData["TicketsID"] = new SelectList(_context.Tickets, "TicketsID", "TicketsID", concertTickets.TicketsID);
            return View(concertTickets);
        }

        // GET: ConcertTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertTickets = await _context.ConcertTickets
                .Include(c => c.Concert)
                .Include(c => c.Tickets)
                .FirstOrDefaultAsync(m => m.ConcertTicketsID == id);
            if (concertTickets == null)
            {
                return NotFound();
            }

            return View(concertTickets);
        }

        // POST: ConcertTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concertTickets = await _context.ConcertTickets.FindAsync(id);
            _context.ConcertTickets.Remove(concertTickets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcertTicketsExists(int id)
        {
            return _context.ConcertTickets.Any(e => e.ConcertTicketsID == id);
        }
    }
}

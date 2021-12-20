using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musictify.Data;
using Musictify.Models;

namespace Musictify.Controllers
{
    public class ConcertController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConcertController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Concert
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Concert.Include(c => c.Stadium);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Concert/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concert
                .Include(c => c.Stadium)
                .FirstOrDefaultAsync(m => m.ConcertID == id);
            if (concert == null)
            {
                return NotFound();
            }

            return View(concert);
        }

        // GET: Concert/Create
        public IActionResult Create()
        {
            ViewData["StadiumID"] = new SelectList(_context.Stadium, "StadiumID", "StadiumID");
            return View();
        }

        // POST: Concert/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConcertID,StadiumID,ConcertDate")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StadiumID"] = new SelectList(_context.Stadium, "StadiumID", "StadiumID", concert.StadiumID);
            return View(concert);
        }

        // GET: Concert/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concert.FindAsync(id);
            if (concert == null)
            {
                return NotFound();
            }
            ViewData["StadiumID"] = new SelectList(_context.Stadium, "StadiumID", "StadiumID", concert.StadiumID);
            return View(concert);
        }

        // POST: Concert/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConcertID,StadiumID,ConcertDate")] Concert concert)
        {
            if (id != concert.ConcertID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcertExists(concert.ConcertID))
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
            ViewData["StadiumID"] = new SelectList(_context.Stadium, "StadiumID", "StadiumID", concert.StadiumID);
            return View(concert);
        }

        // GET: Concert/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concert
                .Include(c => c.Stadium)
                .FirstOrDefaultAsync(m => m.ConcertID == id);
            if (concert == null)
            {
                return NotFound();
            }

            return View(concert);
        }

        // POST: Concert/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concert = await _context.Concert.FindAsync(id);
            _context.Concert.Remove(concert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcertExists(int id)
        {
            return _context.Concert.Any(e => e.ConcertID == id);
        }
    }
}

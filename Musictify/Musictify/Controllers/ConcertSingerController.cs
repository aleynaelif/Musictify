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
    public class ConcertSingerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConcertSingerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConcertSinger
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ConcertSinger.Include(c => c.Concert).Include(c => c.Singer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ConcertSinger/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertSinger = await _context.ConcertSinger
                .Include(c => c.Concert)
                .Include(c => c.Singer)
                .FirstOrDefaultAsync(m => m.ConcertSingerID == id);
            if (concertSinger == null)
            {
                return NotFound();
            }

            return View(concertSinger);
        }

        // GET: ConcertSinger/Create
        public IActionResult Create()
        {
            ViewData["ConcertID"] = new SelectList(_context.Concert, "ConcertID", "ConcertID");
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName");
            return View();
        }

        // POST: ConcertSinger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConcertSingerID,SingerID,ConcertID")] ConcertSinger concertSinger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concertSinger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConcertID"] = new SelectList(_context.Concert, "ConcertID", "ConcertID", concertSinger.ConcertID);
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName", concertSinger.SingerID);
            return View(concertSinger);
        }

        // GET: ConcertSinger/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertSinger = await _context.ConcertSinger.FindAsync(id);
            if (concertSinger == null)
            {
                return NotFound();
            }
            ViewData["ConcertID"] = new SelectList(_context.Concert, "ConcertID", "ConcertID", concertSinger.ConcertID);
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName", concertSinger.SingerID);
            return View(concertSinger);
        }

        // POST: ConcertSinger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConcertSingerID,SingerID,ConcertID")] ConcertSinger concertSinger)
        {
            if (id != concertSinger.ConcertSingerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concertSinger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcertSingerExists(concertSinger.ConcertSingerID))
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
            ViewData["ConcertID"] = new SelectList(_context.Concert, "ConcertID", "ConcertID", concertSinger.ConcertID);
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName", concertSinger.SingerID);
            return View(concertSinger);
        }

        // GET: ConcertSinger/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertSinger = await _context.ConcertSinger
                .Include(c => c.Concert)
                .Include(c => c.Singer)
                .FirstOrDefaultAsync(m => m.ConcertSingerID == id);
            if (concertSinger == null)
            {
                return NotFound();
            }

            return View(concertSinger);
        }

        // POST: ConcertSinger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concertSinger = await _context.ConcertSinger.FindAsync(id);
            _context.ConcertSinger.Remove(concertSinger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcertSingerExists(int id)
        {
            return _context.ConcertSinger.Any(e => e.ConcertSingerID == id);
        }
    }
}

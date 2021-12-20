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
    public class VinylController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VinylController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vinyl
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vinyl.ToListAsync());
        }

        // GET: Vinyl/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinyl = await _context.Vinyl
                .FirstOrDefaultAsync(m => m.VinylID == id);
            if (vinyl == null)
            {
                return NotFound();
            }

            return View(vinyl);
        }

        // GET: Vinyl/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vinyl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VinylID,VinylName,VinylPrice,VinylImageURL")] Vinyl vinyl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vinyl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vinyl);
        }

        // GET: Vinyl/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinyl = await _context.Vinyl.FindAsync(id);
            if (vinyl == null)
            {
                return NotFound();
            }
            return View(vinyl);
        }

        // POST: Vinyl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VinylID,VinylName,VinylPrice,VinylImageURL")] Vinyl vinyl)
        {
            if (id != vinyl.VinylID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vinyl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VinylExists(vinyl.VinylID))
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
            return View(vinyl);
        }

        // GET: Vinyl/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinyl = await _context.Vinyl
                .FirstOrDefaultAsync(m => m.VinylID == id);
            if (vinyl == null)
            {
                return NotFound();
            }

            return View(vinyl);
        }

        // POST: Vinyl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vinyl = await _context.Vinyl.FindAsync(id);
            _context.Vinyl.Remove(vinyl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VinylExists(int id)
        {
            return _context.Vinyl.Any(e => e.VinylID == id);
        }
    }
}

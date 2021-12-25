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
    public class SingerSongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SingerSongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SingerSongs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SingerSongs.Include(s => s.Singer).Include(s => s.Songs);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SingerSongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singerSongs = await _context.SingerSongs
                .Include(s => s.Singer)
                .Include(s => s.Songs)
                .FirstOrDefaultAsync(m => m.SingerSongsID == id);
            if (singerSongs == null)
            {
                return NotFound();
            }

            return View(singerSongs);
        }

        // GET: SingerSongs/Create
        public IActionResult Create()
        {
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName");
            ViewData["SongsID"] = new SelectList(_context.Songs, "SongsID", "SongsName");
            return View();
        }

        // POST: SingerSongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SingerSongsID,SingerID,SongsID")] SingerSongs singerSongs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(singerSongs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName", singerSongs.SingerID);
            ViewData["SongsID"] = new SelectList(_context.Songs, "SongsID", "SongsName", singerSongs.SongsID);
            return View(singerSongs);
        }

        // GET: SingerSongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singerSongs = await _context.SingerSongs.FindAsync(id);
            if (singerSongs == null)
            {
                return NotFound();
            }
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName", singerSongs.SingerID);
            ViewData["SongsID"] = new SelectList(_context.Songs, "SongsID", "SongsName", singerSongs.SongsID);
            return View(singerSongs);
        }

        // POST: SingerSongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SingerSongsID,SingerID,SongsID")] SingerSongs singerSongs)
        {
            if (id != singerSongs.SingerSongsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singerSongs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SingerSongsExists(singerSongs.SingerSongsID))
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
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName", singerSongs.SingerID);
            ViewData["SongsID"] = new SelectList(_context.Songs, "SongsID", "SongsName", singerSongs.SongsID);
            return View(singerSongs);
        }

        // GET: SingerSongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singerSongs = await _context.SingerSongs
                .Include(s => s.Singer)
                .Include(s => s.Songs)
                .FirstOrDefaultAsync(m => m.SingerSongsID == id);
            if (singerSongs == null)
            {
                return NotFound();
            }

            return View(singerSongs);
        }

        // POST: SingerSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singerSongs = await _context.SingerSongs.FindAsync(id);
            _context.SingerSongs.Remove(singerSongs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SingerSongsExists(int id)
        {
            return _context.SingerSongs.Any(e => e.SingerSongsID == id);
        }
    }
}

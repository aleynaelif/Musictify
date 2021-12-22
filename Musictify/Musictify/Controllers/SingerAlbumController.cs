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
    public class SingerAlbumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SingerAlbumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SingerAlbum
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SingerAlbum.Include(s => s.Album).Include(s => s.Singer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SingerAlbum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singerAlbum = await _context.SingerAlbum
                .Include(s => s.Album)
                .Include(s => s.Singer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (singerAlbum == null)
            {
                return NotFound();
            }

            return View(singerAlbum);
        }

        // GET: SingerAlbum/Create
        public IActionResult Create()
        {
            ViewData["AlbumID"] = new SelectList(_context.Album, "AlbumID", "AlbumName");
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName");
            return View();
        }

        // POST: SingerAlbum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AlbumID,SingerID")] SingerAlbum singerAlbum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(singerAlbum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumID"] = new SelectList(_context.Album, "AlbumID", "AlbumName", singerAlbum.AlbumID);
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName", singerAlbum.SingerID);
            return View(singerAlbum);
        }

        // GET: SingerAlbum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singerAlbum = await _context.SingerAlbum.FindAsync(id);
            if (singerAlbum == null)
            {
                return NotFound();
            }
            ViewData["AlbumID"] = new SelectList(_context.Album, "AlbumID", "AlbumName", singerAlbum.AlbumID);
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName", singerAlbum.SingerID);
            return View(singerAlbum);
        }

        // POST: SingerAlbum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AlbumID,SingerID")] SingerAlbum singerAlbum)
        {
            if (id != singerAlbum.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singerAlbum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SingerAlbumExists(singerAlbum.ID))
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
            ViewData["AlbumID"] = new SelectList(_context.Album, "AlbumID", "AlbumName", singerAlbum.AlbumID);
            ViewData["SingerID"] = new SelectList(_context.Singer, "SingerID", "SingerName", singerAlbum.SingerID);
            return View(singerAlbum);
        }

        // GET: SingerAlbum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singerAlbum = await _context.SingerAlbum
                .Include(s => s.Album)
                .Include(s => s.Singer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (singerAlbum == null)
            {
                return NotFound();
            }

            return View(singerAlbum);
        }

        // POST: SingerAlbum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singerAlbum = await _context.SingerAlbum.FindAsync(id);
            _context.SingerAlbum.Remove(singerAlbum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SingerAlbumExists(int id)
        {
            return _context.SingerAlbum.Any(e => e.ID == id);
        }
    }
}

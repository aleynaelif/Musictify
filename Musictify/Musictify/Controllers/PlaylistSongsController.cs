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
    public class PlaylistSongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaylistSongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlaylistSongs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlaylistSongs.Include(p => p.Playlist).Include(p => p.Songs);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlaylistSongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlistSongs = await _context.PlaylistSongs
                .Include(p => p.Playlist)
                .Include(p => p.Songs)
                .FirstOrDefaultAsync(m => m.PlaylistSongsID == id);
            if (playlistSongs == null)
            {
                return NotFound();
            }

            return View(playlistSongs);
        }

        // GET: PlaylistSongs/Create
        public IActionResult Create()
        {
            ViewData["PlaylistID"] = new SelectList(_context.Playlist, "PlaylistID", "PlaylistName");
            ViewData["SongsID"] = new SelectList(_context.Songs, "SongsID", "SongsName");
            return View();
        }

        // POST: PlaylistSongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaylistSongsID,PlaylistID,SongsID")] PlaylistSongs playlistSongs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlistSongs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaylistID"] = new SelectList(_context.Playlist, "PlaylistID", "PlaylistName", playlistSongs.PlaylistID);
            ViewData["SongsID"] = new SelectList(_context.Songs, "SongsID", "SongsName", playlistSongs.SongsID);
            return View(playlistSongs);
        }

        // GET: PlaylistSongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlistSongs = await _context.PlaylistSongs.FindAsync(id);
            if (playlistSongs == null)
            {
                return NotFound();
            }
            ViewData["PlaylistID"] = new SelectList(_context.Playlist, "PlaylistID", "PlaylistName", playlistSongs.PlaylistID);
            ViewData["SongsID"] = new SelectList(_context.Songs, "SongsID", "SongsName", playlistSongs.SongsID);
            return View(playlistSongs);
        }

        // POST: PlaylistSongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaylistSongsID,PlaylistID,SongsID")] PlaylistSongs playlistSongs)
        {
            if (id != playlistSongs.PlaylistSongsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlistSongs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistSongsExists(playlistSongs.PlaylistSongsID))
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
            ViewData["PlaylistID"] = new SelectList(_context.Playlist, "PlaylistID", "PlaylistName", playlistSongs.PlaylistID);
            ViewData["SongsID"] = new SelectList(_context.Songs, "SongsID", "SongsName", playlistSongs.SongsID);
            return View(playlistSongs);
        }

        // GET: PlaylistSongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlistSongs = await _context.PlaylistSongs
                .Include(p => p.Playlist)
                .Include(p => p.Songs)
                .FirstOrDefaultAsync(m => m.PlaylistSongsID == id);
            if (playlistSongs == null)
            {
                return NotFound();
            }

            return View(playlistSongs);
        }

        // POST: PlaylistSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playlistSongs = await _context.PlaylistSongs.FindAsync(id);
            _context.PlaylistSongs.Remove(playlistSongs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistSongsExists(int id)
        {
            return _context.PlaylistSongs.Any(e => e.PlaylistSongsID == id);
        }
    }
}

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
    public class SongsPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SongsPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SongsPage
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Songs.Include(s => s.Album);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SongsPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.SongsID == id);
            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

        private bool SongsExists(int id)
        {
            return _context.Songs.Any(e => e.SongsID == id);
        }
    }
}

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
    public class AlbumPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlbumPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlbumPage
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Album.Include(a => a.Category);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }


        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.AlbumID == id);
        }
    }
}

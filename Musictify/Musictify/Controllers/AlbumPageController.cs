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
        
        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.AlbumID == id);
        }
    }
}

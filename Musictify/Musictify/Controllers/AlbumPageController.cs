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


        public ActionResult Details(int? id)
        {
            List<Album> AlbumName = _context.Album.Where(x => (x.AlbumID == id)).ToList();
            List<Songs> SongsNames = _context.Songs.ToList();

            var MultipleTable = from a in AlbumName
                                join s in SongsNames on a.AlbumID equals s.AlbumID into table1
                                from s in table1.DefaultIfEmpty()
                                select new AlbumSongs {AlbumDetails=a, SongsDetails = s};

            return View(MultipleTable);
        
        }
    }
}

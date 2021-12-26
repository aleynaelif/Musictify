using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musictify.Data;
using Musictify.Models;

namespace Musictify.Controllers
{
    public class PlaylistPage : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaylistPage(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlaylistPage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Playlist.ToListAsync());
        }
        /*public ActionResult Index()
        {
            List<Album> AlbumNames = _context.Album.ToList();
            List<Songs> SongsNames = _context.Songs.ToList();
            List<Singer> SingerNames = _context.Singer.ToList();

            var MultipleTable = from a in AlbumNames
                                join so in SongsNames on a.AlbumID equals so.AlbumID into table1
                                from so in table1.DefaultIfEmpty()
                                join si in SingerNames on so.SongsID equals si.
            return View();
        }*/

        // GET: PlaylistPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .FirstOrDefaultAsync(m => m.PlaylistID == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }
    }
}

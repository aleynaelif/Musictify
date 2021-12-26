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
     
        public ActionResult Details(int? id)
        {
            List<PlaylistSongs> PlaylistSongsNames = _context.PlaylistSongs.Where(x => (x.PlaylistID == id)).ToList();
            List<SingerSongs> SingerSongsNames = _context.SingerSongs.ToList();
            List<Songs> SongsNames = _context.Songs.ToList();

            var MultipleTable = from ps in PlaylistSongsNames
                                join ss in SingerSongsNames on ps.SongsID equals ss.SongsID into table1
                                from ss in table1.DefaultIfEmpty()
                                join so in SongsNames on ss.SongsID equals so.SongsID into table2
                                from so in table2.DefaultIfEmpty()
                                select new AlbumSingerSongs { PlaylistSongsDetails = ps, SingerSongsDetails = ss, SongsDetails=so};
            
            return View(MultipleTable);
        }


    }
}

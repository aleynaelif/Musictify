using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProgrammingProject.Models;

namespace WebProgrammingProject.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            var album = new Album { Singer = "Taylor Swift" , Songs="Red", ReleaseDate = 2021, Rate = 5.0  };
            ViewBag.Category = "Albums";
            return View(album);
        }
    }

    public IActionResult list()
    {
        var song = new List<Songs>()
            {
                new Song {Name="Red", MinuteLenght = 3.43, Genre = "Country "},
                new Song {Name="Nothing New", MinuteLenght = 4.18, Genre = "Country"},
                new Song {Name="I Bet You Think About Me", MinuteLenght = 4.45, Genre = "Country"},
                new Song {Name="22", MinuteLenght = 3.50, Genre = "Country"},
            };

        var album = new Album { Singer = "Taylor Swift" , Songs="Red", ReleaseDate = 2021, Rate = 5.0 };

        var albumViewModel = new AlbumViewModel()
        {
            Album = album,
            Song = song
        };

        return View(albumViewModel);
    }
}

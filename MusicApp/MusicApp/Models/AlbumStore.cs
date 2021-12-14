using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class AlbumStore: DbContext
    {
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Albums> Albums { get; set; }
        public AlbumStore(DbContextOptions<AlbumStore> options):base(options)
        {

        }
    }
}

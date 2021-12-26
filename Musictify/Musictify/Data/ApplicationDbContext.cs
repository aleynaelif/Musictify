using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musictify.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musictify.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database = Album; Trusted_Connection=True;");
        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CD> CD { get; set; }
        public DbSet<Concert> Concert { get; set; }
        public DbSet<ConcertSinger> ConcertSinger { get; set; }
        public DbSet<ConcertTickets> ConcertTickets { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Singer> Singer { get; set; }
        public DbSet<SingerAlbum> SingerAlbum { get; set; }
        public DbSet<SingerSongs> SingerSongs { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<TicketPricing> TicketPricings { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Vinyl> Vinyl { get; set; }
     
    }
}

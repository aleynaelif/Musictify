using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musictify.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musictify.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
        public DbSet<Singer> Singer { get; set; }
    }
}

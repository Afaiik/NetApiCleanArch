using Microsoft.EntityFrameworkCore;
using NetApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetApi.Infrastructure.Data.Configurations;

namespace NetApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SongConfiguration());
            builder.ApplyConfiguration(new ArtistConfiguration());
        }

    }
}

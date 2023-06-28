using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunL_backend.Models;
using Microsoft.Extensions.Logging;


namespace FunL_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Title> Titles { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<TitleGenre>()
                .HasKey(tg => new { tg.TitleId, tg.GenreId });


            base.OnModelCreating(modelBuilder);
        }
    }
}
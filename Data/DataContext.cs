using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Title>()
                .HasMany(t => t.Genres)
                .WithMany(); // Assuming many-to-many relationship between Title and Genre

            // Configure other relationships and mappings

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);

            // Configure other properties of the Genre entity

            base.OnModelCreating(modelBuilder);
        }
    }
}
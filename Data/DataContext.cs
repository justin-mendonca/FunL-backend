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
        public DbSet<Genre> Genres { get; set; }
        public DbSet<StreamingPlatform> StreamingPlatforms { get; set; }
        public DbSet<StreamingServiceInfo> StreamingServiceInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStreamingPlatform> UserStreamingPlatforms { get; set; }
        public DbSet<UserTitle> UserTitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<StreamingPlatform>()
                .HasKey(sp => sp.Id);

            modelBuilder.Entity<StreamingServiceInfo>()
                .HasKey(ssi => ssi.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<UserStreamingPlatform>()
                .HasKey(us => new { us.UserId, us.StreamingPlatformId });

            modelBuilder.Entity<TitleGenre>()
                .HasKey(tg => new { tg.TitleId, tg.GenreId });

            modelBuilder.Entity<TitleGenre>()
                .HasOne(tg => tg.Title)
                .WithMany(t => t.TitleGenres)
                .HasForeignKey(tg => tg.TitleId);

            modelBuilder.Entity<TitleGenre>()
                .HasOne(tg => tg.Genre)
                .WithMany(g => g.TitleGenres)
                .HasForeignKey(tg => tg.GenreId);

            modelBuilder.Entity<StreamingServiceInfo>()
                .HasOne(ssi => ssi.Title)
                .WithMany(t => t.StreamingServices)
                .HasForeignKey(ssi => ssi.TitleId);

            modelBuilder.Entity<StreamingServiceInfo>()
                .HasOne(ssi => ssi.StreamingPlatform)
                .WithMany(sp => sp.TitlesAvailable)
                .HasForeignKey(ssi => ssi.StreamingPlatformId);

            modelBuilder.Entity<UserStreamingPlatform>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserStreamingPlatforms)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserStreamingPlatform>()
                .HasOne(us => us.StreamingPlatform)
                .WithMany(sp => sp.UserStreamingPlatforms)
                .HasForeignKey(us => us.StreamingPlatformId);

            modelBuilder.Entity<UserTitle>()
                .HasKey(ut => new { ut.UserId, ut.TitleId });

            modelBuilder.Entity<UserTitle>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTitles)
                .HasForeignKey(ut => ut.UserId);

            modelBuilder.Entity<UserTitle>()
                .HasOne(ut => ut.Title)
                .WithMany(t => t.UserTitles)
                .HasForeignKey(ut => ut.TitleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
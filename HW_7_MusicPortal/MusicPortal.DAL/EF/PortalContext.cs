using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.Entities;
using System.Reflection.Metadata;

namespace MusicPortal.DAL.EF
{
    public class PortalContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Performer> Performsers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<PerformerGTA> PerformerGTAs { get; set; }
        public DbSet<SourceTrack> SourceTracks { get; set; }
        public PortalContext(DbContextOptions<PortalContext> option) : base(option)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(l => l.Login).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<User>().Property(n => n.NickName).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.Confirmation).HasDefaultValue(false);
            modelBuilder.Entity<User>().HasIndex(l => new { l.Login, l.NickName }).IsUnique(true);


            modelBuilder.Entity<Performer>()
            .HasMany(e => e.Tracks)
            .WithMany(e => e.Performers)
            .UsingEntity<PerformerGTA>();

            modelBuilder.Entity<Performer>()
           .HasMany(e => e.Albums)
           .WithMany(e => e.Performers)
           .UsingEntity<PerformerGTA>();

            modelBuilder.Entity<Performer>()
          .HasMany(e => e.Genres)
          .WithMany(e => e.Performers)
          .UsingEntity<PerformerGTA>();




        }
    }
}

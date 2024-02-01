using FilmoSearch.WebApi.Core.Domain.Models;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.WebApi.Persistence
{
    public class FilmoSearchDbContext : DbContext
    {
        public FilmoSearchDbContext(DbContextOptions<FilmoSearchDbContext> options)
        : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasMany(a => a.Films)
                .WithMany(f => f.Actors)
                .UsingEntity(j => j.ToTable("ActorFilm"));

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Film)
                .WithMany(f => f.Reviews)
                .HasForeignKey(r => r.FilmId);
        }
    }
}

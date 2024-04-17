using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain; 
using Microsoft.EntityFrameworkCore;

namespace FilmoSearch.Persistance
{
    public class FilmoSearchDbContext : DbContext, IFilmoSearchDbContext
    {
        public FilmoSearchDbContext(DbContextOptions<FilmoSearchDbContext> options)
        : base(options) { }

        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ActorFilm> ActorFilm { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
              modelBuilder.Entity<ActorFilm>()
                  .HasKey(af => new { af.FilmId, af.ActorId });

              modelBuilder.Entity<ActorFilm>()
                  .HasOne(sc => sc.Film)
                  .WithMany(s => s.ActorFilms)
                  .HasForeignKey(sc => sc.FilmId);
             
              modelBuilder.Entity<ActorFilm>()
                  .HasOne(sc => sc.Actor)
                  .WithMany(s => s.ActorFilms)
                  .HasForeignKey(sc => sc.ActorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

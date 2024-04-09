using FilmoSearch.Domain;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Application.Interfaces
{
    public interface IFilmoSearchDbContext
    {
        DbSet<Actor> Actors { get; set; }
        DbSet<Film> Films { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<FilmoSearch.Domain.ActorFilm> ActorFilms { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

using FilmoSearch.WebApi.Core.Application.Interfaces;
using FilmoSearch.WebApi.Core.Domain.Models;
using FilmoSearch.WebApi.Persistence;

namespace FilmoSearch.WebApi.Core.Application.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private FilmoSearchDbContext context;
        public FilmRepository(FilmoSearchDbContext context)
        {
            this.context = context;
        }
        public bool CreateFilm(Film film)
        {
            context.Films.Add(film);
            return Save();
        }

        public bool DeleteFilm(Film film)
        {
            context.Films.Remove(film);
            return Save();
        }

        public bool FilmExists(int id)
        {

            return context.Films.Any(f => f.Id == id);
        }

        public Film GetFilm(int id)
        {
            return context.Films.Where(F => F.Id == id).FirstOrDefault();
        }

        public ICollection<Film> GetFilms()
        {
            return context.Films.ToList();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateFilm(Film film)
        {
            context.Films.Update(film);
            return Save();
        }
    }
}

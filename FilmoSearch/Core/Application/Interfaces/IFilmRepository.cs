using FilmoSearch.WebApi.Core.Domain.Models;

namespace FilmoSearch.WebApi.Core.Application.Interfaces
{
    public interface IFilmRepository
    {
        bool CreateFilm(Film film);
        ICollection<Film> GetFilms();
        Film GetFilm(int id);
        bool UpdateFilm(Film film);
        bool DeleteFilm(Film film);
        bool Save();
        bool FilmExists(int id);
    }
}

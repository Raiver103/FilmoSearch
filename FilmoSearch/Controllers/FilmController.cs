using AutoMapper;
using FilmoSearch.WebApi.Core.Application.Interfaces;
using FilmoSearch.WebApi.Core.Domain.Models;
using FilmoSearchT.Dto;
using Microsoft.AspNetCore.Mvc;
using Serilog; 

namespace FilmoSearchT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository filmRepository;
        private readonly IMapper mapper;

        public FilmController(IFilmRepository filmRepository, IMapper mapper)
        {
            this.filmRepository = filmRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Film>))]
        public IActionResult GetFilms()
        {
            var films = mapper.Map<List<FilmDto>>(filmRepository.GetFilms());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Log.Information($"Films Request: GetFilms count: {films.Count}");
            return Ok(films);
        }


        [HttpGet("{filmId}")]
        [ProducesResponseType(200, Type = typeof(Film))]
        [ProducesResponseType(400)]
        public IActionResult GetFilm(int filmId)
        {
            var film = mapper.Map<FilmDto>(filmRepository.GetFilm(filmId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Log.Information($"Films Request: GetFilm id: {film.Id}");
            return Ok(film);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFilm([FromBody] FilmDto filmCreate)
        {
            if (filmCreate == null)
                return BadRequest(ModelState);

            var film = filmRepository.GetFilms()
                .Where(f => f.Title.Trim().ToUpper() == filmCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (film != null)
            {
                ModelState.AddModelError("", "Film already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var filmMap = mapper.Map<Film>(filmCreate);

            if (!filmRepository.CreateFilm(filmMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            Log.Information($"Films Request: CreateFilm id: {filmMap.Id}");
            return Ok("Successfully created");
        }

        [HttpPut("{filmId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFilm(int filmId, [FromBody] FilmDto updatedFilm)
        {
            if (updatedFilm == null)
                return BadRequest(ModelState);

            if (filmId != updatedFilm.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var filmMap = mapper.Map<Film>(updatedFilm);

            if (!filmRepository.UpdateFilm(filmMap))
            {
                ModelState.AddModelError("", "Something went wrong updating film");
                return StatusCode(500, ModelState);
            }

            Log.Information($"Films Request: UpdateFilm id: {updatedFilm.Id}");
            return NoContent();
        }

        [HttpDelete("{filmId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteFilm(int filmId)
        {

            var filmToDelete = filmRepository.GetFilm(filmId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!filmRepository.DeleteFilm(filmToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting film");
            }

            Log.Information($"Films Request: DeleteFilm id: {filmToDelete.Id}");
            return NoContent();
        }
    }
}

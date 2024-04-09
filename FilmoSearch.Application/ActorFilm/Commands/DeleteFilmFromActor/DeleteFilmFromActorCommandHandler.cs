using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Interfaces; 
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Application.ActorFilm.Commands.DeleteFilmFromActor
{
    public class DeleteFilmFromActorCommandHandler : IRequestHandler<DeleteFilmFromActorCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext;

        public DeleteFilmFromActorCommandHandler(IFilmoSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteFilmFromActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _dbContext.Actors.FirstOrDefaultAsync(actor =>
                    actor.FirstName == request.ActorFirstName &&
                    actor.LastName == request.ActorLastName,
                    cancellationToken);

            var film = await _dbContext.Films.FirstOrDefaultAsync(film =>
                   film.Title == request.FilmTitle, cancellationToken);

            if (actor == null || film == null)
            {
                throw new NotFoundException(nameof(ActorFilm), request.FilmTitle);
            }

            var deleteActorFilm = await _dbContext.ActorFilms.FirstOrDefaultAsync(af =>
            af.Film == film && af.FilmId == film.Id && af.Actor == actor && af.ActorId == actor.Id, cancellationToken);

            if (deleteActorFilm == null)
            {
                throw new NotFoundException(nameof(FilmoSearch.Domain.ActorFilm), request.ActorFirstName);
            }

            _dbContext.ActorFilms.Remove(deleteActorFilm);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return actor.Id;
        }
    }
}

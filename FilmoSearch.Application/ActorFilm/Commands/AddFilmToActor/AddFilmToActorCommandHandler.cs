using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Interfaces; 
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Application.ActorFilm.Commands.AddFilmToActor
{
    public class AddFilmToActorCommandHandler : IRequestHandler<AddFilmToActorCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext;

        public AddFilmToActorCommandHandler(IFilmoSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(AddFilmToActorCommand request, CancellationToken cancellationToken)
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
            
            var actorFilm = new FilmoSearch.Domain.ActorFilm
            {
                ActorId = actor.Id,
                FilmId = film.Id,
                Actor = actor,
                Film = film
            }; 

            await _dbContext.ActorFilms.AddAsync(actorFilm, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return actorFilm.ActorId; 
        } 
    }
}

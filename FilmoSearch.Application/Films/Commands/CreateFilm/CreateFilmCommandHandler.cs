using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain; 
using MediatR; 

namespace FilmoSearch.Application.Films.Commands.CreateFilm
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext; 

        public CreateFilmCommandHandler(IFilmoSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        { 
            var film = new Film { Title = request.Title };
            await _dbContext.Films.AddAsync(film, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return film.Id;
        }
    }
}

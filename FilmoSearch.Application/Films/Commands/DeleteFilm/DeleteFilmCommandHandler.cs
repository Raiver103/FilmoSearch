using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain;
using MediatR; 

namespace FilmoSearch.Application.Films.Commands.DeleteFilm
{
    public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext;
        public DeleteFilmCommandHandler(IFilmoSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Films
               .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Film), request.Id);
            }

            _dbContext.Films.Remove(entity); 
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

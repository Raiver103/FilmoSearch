using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Application.Films.Commands.UpdateFilm
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext;

        public UpdateFilmCommandHandler(IFilmoSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Films.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Film), request.Id);
            }

            entity.Title = request.Title; 

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

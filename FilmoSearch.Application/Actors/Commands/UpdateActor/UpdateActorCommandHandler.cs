using AutoMapper;
using AutoMapper.QueryableExtensions;
using FilmoSearch.Application.Actors.Queries.GetActorDetails;
using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Application.Actors.Commands.UpdateActor
{
    public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext;  

        public UpdateActorCommandHandler(IFilmoSearchDbContext dbContext) => (_dbContext) = (dbContext);

        public async Task<int> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Actors.FirstOrDefaultAsync(actor =>
                    actor.Id == request.Id, cancellationToken);

            var filmsQuery = await _dbContext.Actors
               .Where(a => a.Id == request.Id)
               .SelectMany(a => a.ActorFilms)
               .Select(af => af.Film) 
               .ToListAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Actor), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName; 

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

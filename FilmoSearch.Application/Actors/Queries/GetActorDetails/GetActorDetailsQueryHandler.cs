using AutoMapper;
using AutoMapper.QueryableExtensions; 
using FilmoSearch.Application.Common.Exceptions; 
using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Application.Actors.Queries.GetActorDetails
{
    public class GetActorDetailsQueryHandler : IRequestHandler<GetActorDetailsQuery, ActorDetailsVm> 
    {
        private readonly IFilmoSearchDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorDetailsQueryHandler(IFilmoSearchDbContext dbContext
           , IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ActorDetailsVm> Handle(GetActorDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Actors
                .FirstOrDefaultAsync(actor =>
                actor.Id == request.Id, cancellationToken); 

            if (entity == null)
            {
                throw new NotFoundException(nameof(Actor), request.Id);
            }
              
            var filmsQuery = await _dbContext.Actors
               .Where(a => a.Id == request.Id)
               .SelectMany(a => a.ActorFilms)
               .Select(af => af.Film)
               .ProjectTo<FilmsLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new ActorDetailsVm { 
                Films = filmsQuery, 
                Id = entity.Id, 
                FirstNane = entity.FirstName, 
                LastName = entity.LastName 
            };
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using FilmoSearch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;  

namespace FilmoSearch.Application.Actors.Queries.GetActorList
{
    public class GetActorListQueryHandler : IRequestHandler<GetActorListQuery, ActorListVm>
    {
        private readonly IFilmoSearchDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorListQueryHandler(IFilmoSearchDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ActorListVm> Handle(GetActorListQuery request, CancellationToken cancellationToken)
        {
            var actorsQuery = await _dbContext.Actors 
                .ProjectTo<ActorLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ActorListVm { Actors = actorsQuery };
        }
    }
}

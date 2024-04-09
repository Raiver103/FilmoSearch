using AutoMapper;
using AutoMapper.QueryableExtensions; 
using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FilmoSearch.Application.Films.Queries.GetFilmDetails
{
    public class GetFilmDetailsQueryHandler : IRequestHandler<GetFilmDetailsQuery, FilmDetailsVm>
    {
        private readonly IFilmoSearchDbContext _dbContext;
        private readonly IMapper _mapper;


        public GetFilmDetailsQueryHandler(IFilmoSearchDbContext dbContext
           , IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FilmDetailsVm> Handle(GetFilmDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Films.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Film), request.Id);
            }
             

            var reviewsQuery = await _dbContext.Reviews.Where(a => a.FilmId == entity.Id)
                  .ProjectTo<ReviewsLookupDto>(_mapper.ConfigurationProvider)
                  .ToListAsync(cancellationToken);

            var actorsQuery = await _dbContext.Films
               .Where(a => a.Id == request.Id)
               .SelectMany(a => a.ActorFilms)
               .Select(af => af.Actor)
               .ProjectTo<ActorsLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new FilmDetailsVm { 
                Actors = actorsQuery,
                Reviews = reviewsQuery, 
                Title = entity.Title,
                Id = entity.Id 
            };
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions; 
using FilmoSearch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Application.Films.Queries.GetFilmList
{
    public class GetFilmListQueryHandler : IRequestHandler<GetFilmListQuery, FilmListVm>
    {
        private readonly IFilmoSearchDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFilmListQueryHandler(IFilmoSearchDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FilmListVm> Handle(GetFilmListQuery request, CancellationToken cancellationToken)
        {
            var filmsQuery = await _dbContext.Films
                .ProjectTo<FilmLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FilmListVm { Films = filmsQuery };
        }
    }
}

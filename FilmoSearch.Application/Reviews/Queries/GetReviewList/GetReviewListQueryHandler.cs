using AutoMapper;
using AutoMapper.QueryableExtensions; 
using FilmoSearch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Application.Reviews.Queries.GetReviewList
{
    public class GetReviewListQueryHandler : IRequestHandler<GetReviewListQuery, ReviewListVm>
    {
        private readonly IFilmoSearchDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReviewListQueryHandler(IFilmoSearchDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ReviewListVm> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
        {
            var actorsQuery = await _dbContext.Reviews
                .ProjectTo<ReviewLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ReviewListVm { Reviews = actorsQuery };
        }
    }
}

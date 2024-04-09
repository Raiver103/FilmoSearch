using AutoMapper; 
using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Interfaces; 
using FilmoSearch.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Application.Reviews.Queries.GetReviewDetails
{
    public class GetReviewDetailsQueryHandler : IRequestHandler<GetReviewDetailsQuery, ReviewDetailsVm>
    {
        private readonly IFilmoSearchDbContext _dbContext;
        private readonly IMapper _mapper;
         
        public GetReviewDetailsQueryHandler(IFilmoSearchDbContext dbContext, IMapper mapper) => 
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ReviewDetailsVm> Handle(GetReviewDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Review), request.Id);
            }
             
            var filmQuery = await _dbContext.Films.FirstOrDefaultAsync(f => f.Id == entity.FilmId); 

            return new ReviewDetailsVm {
                Id = request.Id,
                Title = entity.Title,
                Description = entity.Description,
                Stars = entity.Stars, 
                Film = filmQuery.Title
            };
        } 
    }
}

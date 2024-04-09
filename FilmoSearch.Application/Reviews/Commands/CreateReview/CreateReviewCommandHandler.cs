using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain;
using MediatR; 

namespace FilmoSearch.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext;

        public CreateReviewCommandHandler(IFilmoSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review { 

                Description = request.Description, 
                Title = request.Title, 
                Stars = request.Stars, 
                FilmId = request.FilmId 
            };

            await _dbContext.Reviews.AddAsync(review, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return review.Id;
        }
    }
}

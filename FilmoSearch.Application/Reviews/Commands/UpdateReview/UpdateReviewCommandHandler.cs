using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext;

        public UpdateReviewCommandHandler(IFilmoSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (entity == null)
            { 
                throw new NotFoundException(nameof(Review), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Stars = request.Stars; 

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

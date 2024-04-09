using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain;
using MediatR; 

namespace FilmoSearch.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext;
        public DeleteReviewCommandHandler(IFilmoSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Reviews
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if(entity == null)
                throw new NotFoundException(nameof(Review), request.Id);

            _dbContext.Reviews.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

using MediatR; 

namespace FilmoSearch.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

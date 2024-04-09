using MediatR; 

namespace FilmoSearch.Application.Reviews.Queries.GetReviewDetails
{
    public class GetReviewDetailsQuery : IRequest<ReviewDetailsVm>
    {
        public int Id { get; set; }
    }
}

using MediatR; 

namespace FilmoSearch.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public int Stars { get; set; } 
    }
}

using MediatR; 

namespace FilmoSearch.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int FilmId { get; set; }
    }
}

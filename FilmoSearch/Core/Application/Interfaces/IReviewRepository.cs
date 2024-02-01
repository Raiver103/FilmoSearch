using FilmoSearch.WebApi.Core.Domain.Models;

namespace FilmoSearch.WebApi.Core.Application.Interfaces
{
    public interface IReviewRepository
    {
        bool CreateReview(Review review);
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        bool UpdateReview(Review review);
        bool DeleteReview(Review review);
        bool Save();
        bool ReviewExists(int id);

    }
}

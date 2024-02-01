using FilmoSearch.WebApi.Core.Application.Interfaces;
using FilmoSearch.WebApi.Core.Domain.Models;
using FilmoSearch.WebApi.Persistence;

namespace FilmoSearch.WebApi.Core.Application.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private FilmoSearchDbContext context;
        public ReviewRepository(FilmoSearchDbContext context)
        {
            this.context = context;
        }
        public bool CreateReview(Review review)
        {
            context.Reviews.Add(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            context.Reviews.Remove(review);
            return Save();
        }

        public Review GetReview(int id)
        {
            return context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return context.Reviews.ToList();
        }

        public bool ReviewExists(int id)
        {

            return context.Reviews.Any(r => r.Id == id);
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            context.Reviews.Update(review);
            return Save();
        }
    }
}

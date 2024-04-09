using FluentValidation; 

namespace FilmoSearch.Application.Reviews.Queries.GetReviewDetails
{
    public class GetReviewDetailsQueryValidator : AbstractValidator<GetReviewDetailsQuery>
    {
        public GetReviewDetailsQueryValidator()
        { 
            RuleFor(review => review.Id).NotEmpty();
        }
    }
}

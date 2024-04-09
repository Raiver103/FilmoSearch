using FluentValidation;

namespace FilmoSearch.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
    {
        public DeleteReviewCommandValidator()
        { 
            RuleFor(review => review.Id).NotEmpty();
        }
    }
}

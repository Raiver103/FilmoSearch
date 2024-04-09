using FluentValidation; 

namespace FilmoSearch.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(createReviewCommand =>
                createReviewCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createReviewCommand =>
                createReviewCommand.Description).NotEmpty().MaximumLength(250);
            RuleFor(createReviewCommand =>
                createReviewCommand.Stars).NotEmpty(); 
            RuleFor(review => review.FilmId).NotEmpty();
        }
    }
}

using FluentValidation;

namespace FilmoSearch.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewCommandValidator()
        {
            RuleFor(createReviewCommand =>
                createReviewCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createReviewCommand =>
                createReviewCommand.Description).NotEmpty().MaximumLength(250);
            RuleFor(createReviewCommand =>
                createReviewCommand.Stars).NotEmpty(); 
        }
    }
}

using FluentValidation; 

namespace FilmoSearch.Application.Films.Commands.CreateFilm
{
    public class CreateFilmCommandValidator : AbstractValidator<CreateFilmCommand>
    {
        public CreateFilmCommandValidator()
        {
            RuleFor(createFilmCommand =>
                createFilmCommand.Title).NotEmpty().MaximumLength(250).WithMessage("eblan?"); 
        }
    }
}

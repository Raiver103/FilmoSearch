using FluentValidation; 

namespace FilmoSearch.Application.Films.Commands.UpdateFilm
{
    public class UpdateFilmCommandValidator : AbstractValidator<UpdateFilmCommand>
    {
        public UpdateFilmCommandValidator()
        { 
            RuleFor(updateFilmCommand => updateFilmCommand.Id).NotEmpty();
            RuleFor(updateFilmCommand =>
                updateFilmCommand.Title).NotEmpty().MaximumLength(250);
        }
    }
}

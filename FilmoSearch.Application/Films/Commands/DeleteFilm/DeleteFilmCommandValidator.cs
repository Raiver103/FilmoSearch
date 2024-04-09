using FluentValidation; 

namespace FilmoSearch.Application.Films.Commands.DeleteFilm
{
    public class DeleteFilmCommandValidator : AbstractValidator<DeleteFilmCommand>
    {
        public DeleteFilmCommandValidator()
        {
            RuleFor(film => film.Id).NotEmpty();
        }
    }
}

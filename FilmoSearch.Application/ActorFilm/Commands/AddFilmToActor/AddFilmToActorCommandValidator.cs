using FluentValidation; 

namespace FilmoSearch.Application.ActorFilm.Commands.AddFilmToActor
{
    public class AddFilmToActorCommandValidator : AbstractValidator<AddFilmToActorCommand>
    {
        public AddFilmToActorCommandValidator()
        {
            RuleFor(addFilmToActorCommand =>
                addFilmToActorCommand.ActorFirstName).NotEmpty().MaximumLength(250);
            RuleFor(addFilmToActorCommand =>
                addFilmToActorCommand.ActorLastName).NotEmpty().MaximumLength(250);
            RuleFor(addFilmToActorCommand =>
                addFilmToActorCommand.FilmTitle).NotEmpty().MaximumLength(250);
        }
    }
}

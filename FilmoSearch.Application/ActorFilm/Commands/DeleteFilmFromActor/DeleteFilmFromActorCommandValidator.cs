using FluentValidation; 

namespace FilmoSearch.Application.ActorFilm.Commands.DeleteFilmFromActor
{
    public class DeleteFilmFromActorCommandValidator : AbstractValidator<DeleteFilmFromActorCommand>
    {
        public DeleteFilmFromActorCommandValidator()
        {
            RuleFor(deleteFilmFromActorCommand =>
                deleteFilmFromActorCommand.ActorFirstName).NotEmpty().MaximumLength(250);
            RuleFor(deleteFilmFromActorCommand =>
                deleteFilmFromActorCommand.ActorLastName).NotEmpty().MaximumLength(250);
            RuleFor(deleteFilmFromActorCommand =>
                deleteFilmFromActorCommand.FilmTitle).NotEmpty().MaximumLength(250);
        }
    }
}

using FluentValidation; 

namespace FilmoSearch.Application.Actors.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(createActorCommand =>
                createActorCommand.FirstName).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand =>
                createNoteCommand.LastName).NotEmpty().MaximumLength(250); 
        }
    }
}

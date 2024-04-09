using FluentValidation; 

namespace FilmoSearch.Application.Actors.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        { 
            RuleFor(updateActorCommand => updateActorCommand.Id).NotEmpty();
            RuleFor(updateActorCommand => updateActorCommand.FirstName).NotEmpty(); 
            RuleFor(updateActorCommand => updateActorCommand.LastName).NotEmpty();
        }
    }
}

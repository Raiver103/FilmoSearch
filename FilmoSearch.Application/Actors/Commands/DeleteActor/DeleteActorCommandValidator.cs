using FluentValidation; 

namespace FilmoSearch.Application.Actors.Commands.DeleteActor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        { 
            RuleFor(deleteActorCommand => deleteActorCommand.Id).NotEmpty(); 
        }
    }
}

using MediatR; 

namespace FilmoSearch.Application.Actors.Commands.CreateActor
{
    public class CreateActorCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}

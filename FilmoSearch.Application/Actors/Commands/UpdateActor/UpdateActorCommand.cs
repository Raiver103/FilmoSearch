using MediatR; 

namespace FilmoSearch.Application.Actors.Commands.UpdateActor
{
    public class UpdateActorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}

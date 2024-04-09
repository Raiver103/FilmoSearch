using MediatR; 

namespace FilmoSearch.Application.Actors.Commands.DeleteActor
{
    public class DeleteActorCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

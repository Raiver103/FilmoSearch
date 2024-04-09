using MediatR; 

namespace FilmoSearch.Application.Actors.Queries.GetActorDetails
{
    public class GetActorDetailsQuery : IRequest<ActorDetailsVm> 
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
    }
}

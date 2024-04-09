using MediatR; 

namespace FilmoSearch.Application.Actors.Queries.GetActorList
{
    public class GetActorListQuery : IRequest<ActorListVm>
    {
    }
}

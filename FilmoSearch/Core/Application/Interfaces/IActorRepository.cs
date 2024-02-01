using FilmoSearch.WebApi.Core.Domain.Models;

namespace FilmoSearch.WebApi.Core.Application.Interfaces
{
    public interface IActorRepository
    {
        bool CreateActor(Actor actor);
        ICollection<Actor> GetActors();
        Actor GetActor(int id);
        bool UpdateActor(Actor actor);
        bool DeleteActor(Actor actor);
        bool Save();
        bool ActorExists(int id);
    }
}

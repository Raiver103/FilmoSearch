using FilmoSearch.WebApi.Core.Application.Interfaces;
using FilmoSearch.WebApi.Core.Domain.Models;
using FilmoSearch.WebApi.Persistence; 

namespace FilmoSearch.WebApi.Core.Application.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private FilmoSearchDbContext context;
        public ActorRepository(FilmoSearchDbContext context)
        {
            this.context = context;
        }

        public bool ActorExists(int id)
        {
            return context.Actors.Any(a => a.Id == id);
        }

        public bool CreateActor(Actor actor)
        {
            context.Add(actor);
            return Save();
        }

        public bool DeleteActor(Actor actor)
        {
            context.Remove(actor);
            return Save();
        }

        public Actor GetActor(int id)
        {
            return context.Actors.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Actor> GetActors()
        {
            return context.Actors.ToList();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateActor(Actor actor)
        {
            context.Update(actor);
            return Save();
        }
    }
}

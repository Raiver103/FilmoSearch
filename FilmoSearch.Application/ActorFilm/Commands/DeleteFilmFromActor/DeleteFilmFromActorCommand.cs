using MediatR; 

namespace FilmoSearch.Application.ActorFilm.Commands.DeleteFilmFromActor
{
    public class DeleteFilmFromActorCommand : IRequest<int>
    {
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
        public string FilmTitle { get; set; }
    }
}

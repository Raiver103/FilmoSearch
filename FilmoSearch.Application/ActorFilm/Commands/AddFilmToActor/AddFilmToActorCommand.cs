using MediatR; 

namespace FilmoSearch.Application.ActorFilm.Commands.AddFilmToActor
{
    public class AddFilmToActorCommand : IRequest<int>
    {
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
        public string FilmTitle { get; set; }
    }
}

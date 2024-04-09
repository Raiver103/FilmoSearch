using MediatR; 

namespace FilmoSearch.Application.Films.Commands.CreateFilm
{
    public class CreateFilmCommand : IRequest<int>
    {
        public string Title { get; set; }
    }
}

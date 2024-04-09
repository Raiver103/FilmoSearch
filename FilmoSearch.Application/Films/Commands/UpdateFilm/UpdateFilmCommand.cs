using MediatR; 

namespace FilmoSearch.Application.Films.Commands.UpdateFilm
{
    public class UpdateFilmCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}

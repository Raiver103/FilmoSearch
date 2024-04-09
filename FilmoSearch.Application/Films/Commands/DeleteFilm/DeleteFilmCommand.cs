using MediatR; 

namespace FilmoSearch.Application.Films.Commands.DeleteFilm
{
    public class DeleteFilmCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

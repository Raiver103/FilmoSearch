using MediatR; 

namespace FilmoSearch.Application.Films.Queries.GetFilmDetails
{
    public class GetFilmDetailsQuery : IRequest<FilmDetailsVm>
    {
        public int Id { get; set; }
    }
}

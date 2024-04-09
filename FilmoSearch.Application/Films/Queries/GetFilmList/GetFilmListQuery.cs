using MediatR; 

namespace FilmoSearch.Application.Films.Queries.GetFilmList
{
    public class GetFilmListQuery : IRequest<FilmListVm>
    {
    }
}

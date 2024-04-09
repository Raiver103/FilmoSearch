using AutoMapper; 
using FilmoSearch.Application.Common.Mappings;
using FilmoSearch.Domain; 

namespace FilmoSearch.Application.Films.Queries.GetFilmDetails
{
    public class FilmDetailsVm : IMapWith<Film>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<ActorsLookupDto> Actors { get; set; }
        public IList<ReviewsLookupDto> Reviews { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FilmDetailsVm>()
                .ForMember(actor => actor.Id,
                    opt => opt.MapFrom(actor => actor.Id))
                .ForMember(actor => actor.Title,
                    opt => opt.MapFrom(actor => actor.Title)) 
                .ForMember(actor => actor.Reviews,
                    opt => opt.MapFrom(actor => actor.Reviews));
        }
    }
}

using AutoMapper; 
using FilmoSearch.Application.Common.Mappings;
using FilmoSearch.Domain; 

namespace FilmoSearch.Application.Reviews.Queries.GetReviewDetails
{
    public class FilmLookupDto : IMapWith<Film>
    {
        public int Id { get; set; }
        public string Tiile { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FilmLookupDto>()
                .ForMember(filmDto => filmDto.Id,
                    opt => opt.MapFrom(film => film.Id))
                .ForMember(filmDto => filmDto.Tiile,
                    opt => opt.MapFrom(film => film.Title));
        }
    }
}
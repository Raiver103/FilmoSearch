using AutoMapper; 
using FilmoSearch.Application.Common.Mappings;
using FilmoSearch.Domain; 

namespace FilmoSearch.Application.Films.Queries.GetFilmDetails
{
    public class ActorsLookupDto : IMapWith<Actor>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Actor, ActorsLookupDto>()
                .ForMember(filmDto => filmDto.Id,
                    opt => opt.MapFrom(film => film.Id))
                .ForMember(filmDto => filmDto.FirstName,
                    opt => opt.MapFrom(film => film.FirstName))
                .ForMember(filmDto => filmDto.LastName,
                    opt => opt.MapFrom(film => film.LastName));
        }
    }
}

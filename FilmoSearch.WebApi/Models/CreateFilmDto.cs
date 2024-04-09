using AutoMapper;
using FilmoSearch.Application.Common.Mappings;
using FilmoSearch.Application.Films.Commands.CreateFilm; 

namespace FilmoSearch.WebApi.Models
{
    public class CreateFilmDto : IMapWith<CreateFilmCommand>
    { 
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFilmDto, CreateFilmCommand>() 
                .ForMember(filmDto => filmDto.Title,
                opt => opt.MapFrom(film => film.Title));
        }
    }
}

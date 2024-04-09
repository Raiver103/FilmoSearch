using AutoMapper;
using FilmoSearch.Application.Common.Mappings; 
using FilmoSearch.Application.Films.Commands.UpdateFilm;  

namespace FilmoSearch.WebApi.Models
{
    public class UpdateFilmDto : IMapWith<UpdateFilmCommand>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateFilmDto, UpdateFilmCommand>()
                .ForMember(filmDto => filmDto.Id,
                opt => opt.MapFrom(film => film.Id))
                .ForMember(filmDto => filmDto.Title,
                opt => opt.MapFrom(film => film.Title));
        }
    }
}

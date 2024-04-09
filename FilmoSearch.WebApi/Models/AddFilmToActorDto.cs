using AutoMapper;
using FilmoSearch.Application.ActorFilm.Commands.AddFilmToActor; 
using FilmoSearch.Application.Common.Mappings;

namespace FilmoSearch.WebApi.Models
{
    public class AddFilmToActorDto : IMapWith<AddFilmToActorCommand>
    {
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
        public string FilmTitle { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddFilmToActorDto, AddFilmToActorCommand>()
                .ForMember(actorFilmCommand => actorFilmCommand.ActorFirstName,
                    opt => opt.MapFrom(actorFilmDto => actorFilmDto.ActorFirstName)) 
                .ForMember(actorFilmCommand => actorFilmCommand.ActorLastName,
                    opt => opt.MapFrom(actorFilmDto => actorFilmDto.ActorLastName))
                .ForMember(actorFilmCommand => actorFilmCommand.FilmTitle,
                    opt => opt.MapFrom(actorFilmDto => actorFilmDto.FilmTitle));
        }
    }
}

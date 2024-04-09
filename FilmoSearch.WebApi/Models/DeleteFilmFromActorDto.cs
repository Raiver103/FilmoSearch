using AutoMapper; 
using FilmoSearch.Application.ActorFilm.Commands.DeleteFilmFromActor;
using FilmoSearch.Application.Common.Mappings;

namespace FilmoSearch.WebApi.Models
{
    public class DeleteFilmFromActorDto : IMapWith<DeleteFilmFromActorCommand>
    {
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
        public string FilmTitle { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeleteFilmFromActorDto, DeleteFilmFromActorCommand>()
                .ForMember(actorFilmCommand => actorFilmCommand.ActorFirstName,
                    opt => opt.MapFrom(actorFilmDto => actorFilmDto.ActorFirstName))
                .ForMember(actorFilmCommand => actorFilmCommand.ActorLastName,
                    opt => opt.MapFrom(actorFilmDto => actorFilmDto.ActorLastName))
                .ForMember(actorFilmCommand => actorFilmCommand.FilmTitle,
                    opt => opt.MapFrom(actorFilmDto => actorFilmDto.FilmTitle));
        }
    }
}

using AutoMapper;
using FilmoSearch.Application.Actors.Commands.CreateActor;
using FilmoSearch.Application.Common.Mappings;

namespace FilmoSearch.WebApi.Models
{
    public class CreateActorDto : IMapWith<CreateActorCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateActorDto, CreateActorCommand>()
                .ForMember(actorCommand => actorCommand.FirstName,
                    opt => opt.MapFrom(actorDto => actorDto.FirstName))
                .ForMember(actorCommand => actorCommand.LastName,
                    opt => opt.MapFrom(actorDto => actorDto.LastName));
        }
    }
}

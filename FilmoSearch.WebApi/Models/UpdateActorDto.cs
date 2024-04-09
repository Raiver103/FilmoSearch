using AutoMapper; 
using FilmoSearch.Application.Actors.Commands.UpdateActor;
using FilmoSearch.Application.Common.Mappings; 

namespace FilmoSearch.WebApi.Models
{
    public class UpdateActorDto : IMapWith<UpdateActorCommand>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateActorDto, UpdateActorCommand>()
                .ForMember(actorCommand => actorCommand.Id,
                    opt => opt.MapFrom(actorDto => actorDto.Id))
                .ForMember(actorCommand => actorCommand.FirstName,
                    opt => opt.MapFrom(actorDto => actorDto.FirstName))
                .ForMember(actorCommand => actorCommand.LastName,
                    opt => opt.MapFrom(actorDto => actorDto.LastName));
        }
    }
}

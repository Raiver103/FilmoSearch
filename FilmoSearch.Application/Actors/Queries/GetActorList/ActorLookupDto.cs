using AutoMapper;
using FilmoSearch.Application.Common.Mappings;
using FilmoSearch.Domain; 

namespace FilmoSearch.Application.Actors.Queries.GetActorList
{
    public class ActorLookupDto : IMapWith<Actor>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Actor, ActorLookupDto>()
                .ForMember(actorDto => actorDto.Id,
                    opt => opt.MapFrom(actor => actor.Id))
                .ForMember(actorDto => actorDto.FirstName,
                    opt => opt.MapFrom(actor => actor.FirstName))
                .ForMember(actorDto => actorDto.LastName,
                    opt => opt.MapFrom(actor => actor.LastName));
        }
    }
}

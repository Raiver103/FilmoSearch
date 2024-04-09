using AutoMapper;
using FilmoSearch.Application.Common.Mappings;
using FilmoSearch.Domain; 

namespace FilmoSearch.Application.Actors.Queries.GetActorDetails
{
    public class ActorDetailsVm : IMapWith<Actor>                     
    {
        public int Id { get; set; }
        public string FirstNane { get; set; }
        public string LastName { get; set; }
        public IList<FilmsLookupDto> Films { get; set; } 

        public void Mapping(Profile profile)                          
        {
            profile.CreateMap<Actor, ActorDetailsVm>()
                .ForMember(actor => actor.FirstNane,
                    opt => opt.MapFrom(actor => actor.FirstName))
                .ForMember(actor => actor.LastName,
                    opt => opt.MapFrom(actor => actor.LastName))
                .ForMember(actor => actor.Id,
                    opt => opt.MapFrom(actor => actor.Id));
        }
    }
}

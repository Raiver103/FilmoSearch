using AutoMapper; 
using FilmoSearch.Application.Common.Mappings;
using FilmoSearch.Domain; 

namespace FilmoSearch.Application.Films.Queries.GetFilmDetails
{
    public class ReviewsLookupDto : IMapWith<Review>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewsLookupDto>()
                .ForMember(actor => actor.Id,
                    opt => opt.MapFrom(actor => actor.Id))
                .ForMember(actor => actor.Title,
                    opt => opt.MapFrom(actor => actor.Title))
                .ForMember(actor => actor.Description,
                    opt => opt.MapFrom(actor => actor.Description))
                .ForMember(actor => actor.Stars,
                    opt => opt.MapFrom(actor => actor.Stars));
        }
    }
}

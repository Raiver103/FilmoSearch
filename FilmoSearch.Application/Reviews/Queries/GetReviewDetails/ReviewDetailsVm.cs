using AutoMapper;
using FilmoSearch.Application.Common.Mappings; 
using FilmoSearch.Domain; 

namespace FilmoSearch.Application.Reviews.Queries.GetReviewDetails
{
    public class ReviewDetailsVm : IMapWith<Review>
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public string Film { get; set; } 
          
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewDetailsVm>()
                .ForMember(review => review.Id,
                    opt => opt.MapFrom(review => review.Id))
                .ForMember(review => review.Title,
                    opt => opt.MapFrom(actor => actor.Title))
                .ForMember(review => review.Description,
                    opt => opt.MapFrom(review => review.Description))
                .ForMember(review => review.Stars,
                    opt => opt.MapFrom(review => review.Stars))
                .ForMember(review => review.Film,  
                         opt => opt.MapFrom(review => review.Film));
        }
    }
}

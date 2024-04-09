using AutoMapper;
using FilmoSearch.Application.Common.Mappings;
using FilmoSearch.Domain; 

namespace FilmoSearch.Application.Reviews.Queries.GetReviewList
{
    public class ReviewLookupDto : IMapWith<Review>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public Film Film { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewLookupDto>()
                .ForMember(reviewDto => reviewDto.Id,
                opt => opt.MapFrom(review => review.Id))
                .ForMember(reviewDto => reviewDto.Title,
                opt => opt.MapFrom(review => review.Title))
                .ForMember(reviewDto => reviewDto.Description,
                opt => opt.MapFrom(review => review.Description))
                .ForMember(reviewDto => reviewDto.Film,
                opt => opt.MapFrom(review => review.Film))
                .ForMember(reviewDto => reviewDto.Stars,
                opt => opt.MapFrom(review => review.Stars));
        }
    }
}

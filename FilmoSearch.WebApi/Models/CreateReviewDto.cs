using AutoMapper;
using FilmoSearch.Application.Common.Mappings; 
using FilmoSearch.Application.Reviews.Commands.CreateReview;

namespace FilmoSearch.WebApi.Models
{
    public class CreateReviewDto : IMapWith<CreateReviewCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int FilmId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateReviewDto, CreateReviewCommand>()
                .ForMember(reviewDto => reviewDto.Title,
                opt => opt.MapFrom(review => review.Title))
                .ForMember(reviewDto => reviewDto.Description,
                opt => opt.MapFrom(review => review.Description))
                .ForMember(reviewDto => reviewDto.Stars,
                opt => opt.MapFrom(review => review.Stars));
        }
    }
}

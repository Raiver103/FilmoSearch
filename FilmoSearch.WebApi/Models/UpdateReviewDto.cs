using AutoMapper;
using FilmoSearch.Application.Common.Mappings; 
using FilmoSearch.Application.Reviews.Commands.UpdateReview;

namespace FilmoSearch.WebApi.Models
{
    public class UpdateReviewDto : IMapWith<UpdateReviewCommand>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateReviewDto, UpdateReviewCommand>()
                .ForMember(reviewDto => reviewDto.Id,
                opt => opt.MapFrom(review => review.Id))
                .ForMember(reviewDto => reviewDto.Title,
                opt => opt.MapFrom(review => review.Title))
                .ForMember(reviewDto => reviewDto.Description,
                opt => opt.MapFrom(review => review.Description))
                .ForMember(reviewDto => reviewDto.Stars,
                opt => opt.MapFrom(review => review.Stars));
        }
    }
}

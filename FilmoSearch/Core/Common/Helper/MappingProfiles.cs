using AutoMapper;
using FilmoSearch.WebApi.Core.Domain.Models;
using FilmoSearchT.Dto;

namespace FilmoSearch.WebApi.Core.Common.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>();
            CreateMap<Film, FilmDto>();
            CreateMap<FilmDto, Film>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
        }
    }
}

using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.PosterImage, opt => opt.MapFrom(src => src.PosterImage.UrlImage))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}

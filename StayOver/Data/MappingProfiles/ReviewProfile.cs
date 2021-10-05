using AutoMapper;
using StayOver.Data.Dtos;
using StayOver.Models;

namespace StayOver.Data.MappingProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewCreateDto, Review>();
            CreateMap<Review, ReviewReadDto>();
        }
    }
}

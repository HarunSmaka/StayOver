using AutoMapper;
using StayOver.Data.Dtos;
using StayOver.Models;

namespace StayOver.Data.MappingProfiles
{
    public class AccommodationProfile : Profile
    {
        public AccommodationProfile()
        {
            CreateMap<AccommodationCreateDto, Accommodation>().ForMember(a => a.GalleryFiles, opt => opt.Ignore());
            CreateMap<Accommodation, AccommodationReadDto>();         
            CreateMap<AccommodationReadDto, Accommodation>().ForMember(a => a.GalleryFiles, opt => opt.Ignore());
            CreateMap<AccommodationUpdateDto, Accommodation>().ForMember(a => a.GalleryFiles, opt => opt.Ignore());
        }
    }
}

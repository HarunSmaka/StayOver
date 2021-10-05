using AutoMapper;
using StayOver.Data.Dtos;
using StayOver.Models;

namespace StayOver.Data.MappingProfiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<Reservation, ReservationReadDto>();           
        }
    }
}

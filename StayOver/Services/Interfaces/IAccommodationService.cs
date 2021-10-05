using StayOver.Data.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Services.Interfaces
{
    public interface IAccommodationService
    {
        public IQueryable<AccommodationReadDto> GetAccommodations();
        public IQueryable<AccommodationReadDto> GetUsersAccommodations(string userId);
        public Task<AccommodationReadDto> GetAccommodationByIdAsync(int? id);
        public Task AddAccommodationAsync(AccommodationCreateDto accommodationCreateDto);
        public Task<bool> UpdateAccommodationAsync(AccommodationUpdateDto accommodationUpdateDto);
        public Task<bool> DeleteAccommodationAsync(int id);      
        public IQueryable<AccommodationReadDto> GetSearchedAccommodations(string titleSearch, string citySearch, int guestNumber, DateTime startDate, DateTime endDate);
        public Task<bool> OwnsAccommodations(string userId);
    }
}

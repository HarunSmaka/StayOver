using StayOver.Data.Dtos;
using StayOver.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Repos.Interfaces
{
    public interface IAccommodationRepo
    {
        public IQueryable<AccommodationReadDto> GetAccommodations();
        public IQueryable<AccommodationReadDto> GetUsersAccommodations(string userId);
        public Task<Accommodation> GetAccommodationByIdAsync(int? id);
        public Task AddAccommodationAsync(Accommodation accommodation);
        public Task<bool> UpdateAccommodationAsync(Accommodation accommodation);
        public Task<bool> DeleteAccommodationAsync(int id);
        public IQueryable<AccommodationReadDto> GetSearchedAccommodations(string titleSearch, string citySearch, int guestNumber, DateTime startDate, DateTime endDate);
        public Task<bool> OwnsAccommodations(string userId);
    }
}

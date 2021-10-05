using StayOver.Data.Dtos;
using StayOver.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Services.Interfaces
{
    public interface IReservationService
    {
        public IQueryable<ReservationReadDto> GetVisitorsReservations(string visitorId);
        public IQueryable<ReservationReadDto> GetReservationsHistoryToOwner(string ownerId);
        public IQueryable<ReservationReadDto> GetActiveReservationsToOwner(string ownerId);
        public Task<IEnumerable<Reservation>> GetAccommodationReservationsAsync(int accommodationId);
        public Task<ReservationReadDto> GetReservationByIdAsync(int reservationId);
        public Task<int> AddReservationAsync(ReservationCreateDto reservationCreateDto);
        public Task<bool> DeleteReservationAsync(int id);
        public Task<bool> IsReviewedAsync(int reservationId);
    }
}

using StayOver.Data.Dtos;
using StayOver.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Repos.Interfaces
{
    public interface IReservationRepo
    {
        public IQueryable<ReservationReadDto> GetVisitorsReservations(string visitorId);
        public IQueryable<ReservationReadDto> GetReservationsHistoryToOwner(string ownerId);
        public IQueryable<ReservationReadDto> GetActiveReservationsToOwner(string ownerId);
        public Task<IEnumerable<Reservation>> GetAccommodationReservationsAsync(int accommodationId);
        public Task<Reservation> GetReservationByIdAsync(int reservationId);
        public Task<int> AddReservationAsync(Reservation reservation);
        public Task<bool> DeleteReservationAsync(int id);
        public Task<bool> IsReviewedAsync(int reservationId);
    }
}

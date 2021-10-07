using AutoMapper;
using StayOver.Data.Dtos;
using StayOver.Models;
using StayOver.Repos.Interfaces;
using StayOver.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepo _repo;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> AddReservationAsync(ReservationCreateDto reservationCreateDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationCreateDto);
            return await _repo.AddReservationAsync(reservation);
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            return await _repo.DeleteReservationAsync(id);
        }

        public IQueryable<ReservationReadDto> GetReservationsHistoryToOwner(string ownerId)
        {
            return  _repo.GetReservationsHistoryToOwner(ownerId);
        }

        public IQueryable<ReservationReadDto> GetActiveReservationsToOwner(string ownerId)
        {
            return  _repo.GetActiveReservationsToOwner(ownerId);
        }

        public async Task<IEnumerable<Reservation>> GetAccommodationReservationsAsync(int accommodationId)
        {
            return await _repo.GetAccommodationReservationsAsync(accommodationId);
        }

        public IQueryable<ReservationReadDto>GetVisitorsReservations(string visitorId)
        {
            return _repo.GetVisitorsReservations(visitorId);
        }

        public async Task<ReservationReadDto> GetReservationByIdAsync(int reservationId)
        {
            var result = await _repo.GetReservationByIdAsync(reservationId);
            var reservation = _mapper.Map<ReservationReadDto>(result);
            return reservation;
        }

        public async Task<bool> IsReviewedAsync(int reservationId)
        {
            return await _repo.IsReviewedAsync(reservationId);
        }
    }
}

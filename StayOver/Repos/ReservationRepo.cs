using Microsoft.EntityFrameworkCore;
using StayOver.Data;
using StayOver.Data.Dtos;
using StayOver.Models;
using StayOver.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Repos
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly StayOverDbContext _context;

        public ReservationRepo(StayOverDbContext context)
        {
            _context = context;
        }

        public IQueryable<ReservationReadDto> GetVisitorsReservations(string visitorId)
        {
            return _context.Reservations
                .Where(r => r.VisiterId == visitorId)
                .Include(r => r.Visiter)
                .Include(r => r.Accommodation)
                .Select(r => new ReservationReadDto()
                    {
                        ReservationId = r.ReservationId,
                        CreatedAt = r.CreatedAt,
                        CheckIn = r.CheckIn,
                        CheckOut = r.CheckOut,
                        Visiter = r.Visiter,
                        Accommodation = r.Accommodation,      
                    }
                );
        }

        public IQueryable<ReservationReadDto> GetActiveReservationsToOwner(string ownerId)
        {
            return  _context
                .Reservations
                .Where(r => r.Accommodation.OwnerId == ownerId)
                .Where(r => r.CheckOut >= DateTime.Now)
                .Include(r => r.Visiter).Include(r => r.Accommodation)
                .Select(r => new ReservationReadDto()
                    {
                        ReservationId = r.ReservationId,
                        CreatedAt = r.CreatedAt,
                        CheckIn = r.CheckIn,
                        CheckOut = r.CheckOut,
                        Visiter = r.Visiter,
                        Accommodation = r.Accommodation,
                    }
                );
        }

        public IQueryable<ReservationReadDto> GetReservationsHistoryToOwner(string ownerId)
        {
            return _context
                .Reservations
                .Where(r => r.Accommodation.OwnerId == ownerId)
                .Where(r => r.CheckOut < DateTime.Now)
                .Include(r => r.Visiter)
                .Include(r => r.Accommodation)
               .Select(r => new ReservationReadDto()
                    {
                        ReservationId = r.ReservationId,
                        CreatedAt = r.CreatedAt,
                        CheckIn = r.CheckIn,
                        CheckOut = r.CheckOut,
                        Visiter = r.Visiter,
                        Accommodation = r.Accommodation,
                    }
                );
        }

        public async Task<IEnumerable<Reservation>> GetAccommodationReservationsAsync(int accommodationId)
        {
            return await _context
                .Reservations
                .Where(r => r.Accommodation.AccommodationId == accommodationId)
                .Include(r => r.Visiter)
                .ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            return await _context
                .Reservations
                .Include(r => r.Visiter)
                .Include(r => r.Accommodation)
                .Include("Accommodation.Gallery")
                .Include("Accommodation.City")
                .Include("Accommodation.Owner")
                .Include(r => r.Review)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);
        }

        public async Task<int> AddReservationAsync(Reservation reservation)
        {
            await _context
                .Reservations
                .AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation.ReservationId;
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            var reservation = _context
                .Reservations
                .Where(r => r.ReservationId == id)
                .FirstOrDefault();

            _context.Reservations.Remove(reservation);
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> IsReviewedAsync(int reservationId)
        {
            var result = await _context
                .Reviews
                .Where(r => r.ReservationId == reservationId).ToListAsync();

            return result.Count > 0;
        }
    }
}


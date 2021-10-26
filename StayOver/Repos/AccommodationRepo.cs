using Microsoft.EntityFrameworkCore;
using StayOver.Data;
using StayOver.Data.Dtos;
using StayOver.Models;
using StayOver.Repos.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Repos
{
    public class AccommodationRepo : IAccommodationRepo
    {
        private readonly StayOverDbContext _context;
        private readonly IGalleryRepo _galleryRepo;

        public AccommodationRepo(StayOverDbContext context,IGalleryRepo galleryRepo)
        {
            _context = context;
            _galleryRepo = galleryRepo;
        }

        public IQueryable<AccommodationReadDto> GetAccommodations()
        {
            return _context
                .Accommodations
                .AsNoTracking()
                .Where(a => a.Active == true)
                .Include(a => a.City)
                .Include(a => a.Gallery)
                .Include(a => a.Owner)
                .Select(a => new AccommodationReadDto()
                {
                    AccommodationId = a.AccommodationId,
                    Title = a.Title,
                    Price = a.Price,
                    Address = a.Address,
                    Description = a.Description,
                    Active = a.Active,
                    GuestNumber = a.GuestNumber,
                    Gallery = a.Gallery,
                    City = a.City,
                    Owner = a.Owner
                });
        }

        public IQueryable<AccommodationReadDto> GetUsersAccommodations(string userId)
        {
            return _context
                .Accommodations.AsNoTracking()
                .Include(a => a.City)
                .Include(a => a.Gallery)
                .Include(a => a.Owner)
                .Where(a => a.OwnerId == userId)
                .Select(a => new AccommodationReadDto()
                {
                    AccommodationId = a.AccommodationId,
                    Title = a.Title,
                    Price = a.Price,
                    Address = a.Address,
                    Description = a.Description,
                    Active = a.Active,
                    GuestNumber = a.GuestNumber,
                    Gallery = a.Gallery,
                    City = a.City,
                    Owner = a.Owner
                });
        }

        public async Task<Accommodation> GetAccommodationByIdAsync(int? id)
        {
            return await _context.Accommodations.AsNoTracking()
                .Where(a => a.AccommodationId == id)
                .Include(a => a.City)
                .Include(a => a.Owner)
                .Include(accommodation => accommodation.Gallery)
                .Include(a => a.Reservations)
                .Include("Reservations.Visiter")
                .Include("Reservations.Review")
                .SingleAsync();
        }

        public async Task AddAccommodationAsync(Accommodation accommodation)
        {
            await _context.Accommodations.AddAsync(accommodation);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAccommodationAsync(Accommodation accommodation)
        {
            _context.Update(accommodation);

            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> DeleteAccommodationAsync( int id)
        {
            var accommodation =  _context.
                Accommodations
                .AsNoTracking()
                .Include(a => a.Reservations)
                .Where(a => a.AccommodationId == id)
                .Single();

            await _galleryRepo.DeleteGalleryAsync(id);

            _context.Accommodations.Remove(accommodation);

            return await _context.SaveChangesAsync() >= 0;
        }

        public IQueryable<AccommodationReadDto> GetSearchedAccommodations(string titleSearch, string citySearch, int guestNumber, DateTime startDate, DateTime endDate)
        {
            IQueryable<Reservation> bookings = null;

            if(startDate != DateTime.MaxValue)
            {
                bookings = _context.Reservations
                  .Where(r =>
                     (r.CheckIn >= startDate && r.CheckIn < endDate)
                  || (r.CheckIn >= startDate && r.CheckOut < endDate)
                  || (r.CheckIn < startDate && r.CheckOut > endDate)
                  || (r.CheckIn < startDate && r.CheckOut > startDate)
                  );
            }

            var result = _context
                .Accommodations.AsNoTracking()
                .Where(a => a.Active == true)
                .Where(a => a.Title.Contains(titleSearch ?? ""))
                .Where(a => a.City.Name.Contains(citySearch ?? ""))
                .Where(a => guestNumber > 0 ? a.GuestNumber == guestNumber : true)
                .Include(a => a.Gallery)
                .Include(a => a.City)
                .Include(a => a.Owner)
                .Include(a => a.Reservations)
                .Where(a => bookings == null ? true : !bookings.Any(r => r.AccommodationId == a.AccommodationId));

            return result
                .Select(a => new AccommodationReadDto()
                {
                    AccommodationId = a.AccommodationId,
                    Title = a.Title,
                    Price = a.Price,
                    Address = a.Address,
                    Description = a.Description,
                    Active = a.Active,
                    GuestNumber = a.GuestNumber,
                    Gallery = a.Gallery,
                    City = a.City,
                    Owner = a.Owner
                });
        }

        public async Task<bool> OwnsAccommodations(string userId)
        {
            var result = await _context.Accommodations
                .FirstOrDefaultAsync(m => m.Owner.Id == userId);

            if (result != null)
            {
                return true;
            }

            return false;
        }
    }
}

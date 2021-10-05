using Microsoft.EntityFrameworkCore;
using StayOver.Data;
using StayOver.Data.Dtos;
using StayOver.Models;
using StayOver.Repos.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Repos
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly StayOverDbContext _context;

        public ReviewRepo(StayOverDbContext context)
        {
            _context = context;
        }

        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public IQueryable<ReviewReadDto> GetReviews(string Id)
        {
            return _context
                .Reviews
                .Include(r => r.User)
                .Where(r => r.ApplicationUserId == Id)
                .Select(r => new ReviewReadDto()
                {
                    ReservationId = r.ReservationId,
                    User = r.User,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    PublishedDate = r.PublishedDate,
                });
        }
        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews
            .Where(r => r.ReservationId == id).SingleAsync();
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            var review = await GetReviewByIdAsync(id);

             _context
                .Reviews
                .Remove(review);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}


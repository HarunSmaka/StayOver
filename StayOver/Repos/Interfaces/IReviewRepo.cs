using StayOver.Data.Dtos;
using StayOver.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Repos.Interfaces
{
    public interface IReviewRepo
    {
        public void AddReview(Review review);
        public IQueryable<ReviewReadDto> GetReviews(string Id);
        public Task<bool> DeleteReservationAsync(int id);
    }
}

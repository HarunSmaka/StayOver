using StayOver.Data.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Services.Interfaces
{
    public interface IReviewService
    {
        public void AddReview(ReviewCreateDto reviewCreateDto);
        public IQueryable<ReviewReadDto> GetReviews(string Id);
        public Task<bool> DeleteReservationAsync(int id);
    }
}

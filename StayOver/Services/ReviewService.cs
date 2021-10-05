using AutoMapper;
using StayOver.Data.Dtos;
using StayOver.Models;
using StayOver.Repos.Interfaces;
using StayOver.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepo _repo;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void AddReview(ReviewCreateDto reviewCreateDto)
        {
            var review = _mapper.Map<Review>(reviewCreateDto);
             _repo.AddReview(review);
        }

        public IQueryable<ReviewReadDto> GetReviews(string Id)
        {
            return _repo.GetReviews(Id);
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            return await _repo.DeleteReservationAsync(id);
        }
    }
}

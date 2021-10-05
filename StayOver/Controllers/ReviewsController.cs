using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayOver.Data;
using StayOver.Data.Dtos;
using StayOver.Helper;
using StayOver.Services.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StayOver.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly StayOverDbContext _context;
        private readonly IReviewService _service;

        public ReviewsController(StayOverDbContext context, IReviewService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index(string Id, int? pageNumber)
        {
            var pageSize = 3;
            try
            {
                var result = _service.GetReviews(Id);

                return View(await PaginatedList<ReviewReadDto>.CreateAsync(result, pageNumber ?? 1, pageSize));
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(string comment, string rating, string accommodationId, string reservationId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var review = new ReviewCreateDto()
            {
                Comment = comment,
                Rating = Int32.Parse(rating),
                PublishedDate = DateTime.Now,
                ApplicationUserId = userId,
                ReservationId = Int32.Parse(reservationId),
            };
            try
            {
                _service.AddReview(review); 
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Details", "Accommodations", new { id = accommodationId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview([FromBody] string Id)
        {
            var reviewId = Int32.Parse(Id);
            var isSuccess = await _service.DeleteReservationAsync(reviewId);

            if(isSuccess)
            {
                return Json("Success");
            }

            return Json("Error");
        }
    }
}

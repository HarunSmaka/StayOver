using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StayOver.Data;
using StayOver.Data.Dtos;
using StayOver.Helper;
using StayOver.Models;
using StayOver.Services.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StayOver.Controllers
{
    [Authorize]
    public class AccommodationsController : Controller
    {
        private readonly StayOverDbContext _context;
        private readonly IAccommodationService _accommodationService;
        private readonly IGalleryService _galleryService;
        private readonly IReservationService _reservationService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public AccommodationsController(StayOverDbContext context, IAccommodationService accommodationService, 
            IGalleryService galleryService, IReservationService reservationService,
            IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _context = context;
            _accommodationService = accommodationService;
            _galleryService = galleryService;
            _reservationService = reservationService;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        // GET: Accommodations
        public async Task<IActionResult> Index(int? pageNumber, string Id = "")
        {
            int pageSize = 3;
            string userId;
            try
            {
                if (string.IsNullOrEmpty(Id))
                {
                    userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                }
                else
                {
                    userId = Id;
                }

                var result =  _accommodationService.GetUsersAccommodations(userId);

                return View(await PaginatedList<AccommodationReadDto>.CreateAsync(result, pageNumber ?? 1, pageSize));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }   
        }

        // GET: Accommodations/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            ViewBag.userId = userId;

            try
            {
                var result = await _accommodationService.GetAccommodationByIdAsync(id);
                var reservationsWithReviews = result.Reservations.Where(r => r.Review != null);
                var ratingCount = reservationsWithReviews.Select(r => r.Review).Count();
                var isOwner = result.Owner.Id == userId;

                double rating;

                if(ratingCount > 0)
                {
                    double ratingSum = reservationsWithReviews.Select(r => r.Review).Sum(r => r.Rating);
                    rating = Math.Round((ratingSum / ratingCount), 2);
                }
                else
                {
                    rating = 0;
                }

                ViewBag.reservationsWithReviews = reservationsWithReviews;
                ViewBag.rating = rating;
                ViewBag.isOwner = isOwner;
                ViewBag.reviewNumber = ratingCount;


                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: Accommodations/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "CityId", "Name");
            return View();
        }

        // POST: Accommodations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccommodationId,Title,Price,Address,Description,Available,GuestNumber,ShowPhoneNumber,CityId,GalleryFiles")] AccommodationCreateDto accommodation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                if (ModelState.IsValid || userId != null)
                {
                    accommodation.OwnerId = userId;
                    await _accommodationService.AddAccommodationAsync(accommodation);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }



            ViewData["CityName"] = new SelectList(_context.Set<City>(), "CityId", "Name");

            return View(accommodation);
        }

        // GET: Accommodations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _accommodationService.GetAccommodationByIdAsync(id);

            if (result == null)
            {
                return RedirectToAction("Error", "Home");
            }

            ViewData["CityName"] = new SelectList(_context.Set<City>(), "CityId", "Name", result.City.CityId);

            return View(result);
        }

        // POST: Accommodations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccommodationId,Title,Price,Address,Description,Active,ShowPhoneNumber,GuestNumber")] AccommodationUpdateDto accommodation, int cityId, IFormFileCollection galleryFiles)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid && userId != null)
            {
                try
                {
                    accommodation.GalleryFiles = galleryFiles;

                    accommodation.OwnerId = userId;
                    accommodation.CityId = cityId;

                    var result = await _accommodationService.UpdateAccommodationAsync(accommodation);

                    if (!result)
                    {
                        return BadRequest("Accommodation could not be updated");
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }

                return RedirectToAction(nameof(Index));
            }

            return View(accommodation);
        }

        // GET: Accommodations/Delete/5     
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var accommodation = await _accommodationService.GetAccommodationByIdAsync(id);
                return View(accommodation);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: Accommodations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _accommodationService.DeleteAccommodationAsync(id);

                if (!result)
                {
                    return BadRequest("Accommodation could not be deleted");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage([FromBody] string Id)
        {
            var imageId = Int32.Parse(Id);

            try
            {
                await _galleryService.DeleteGalleryImageAsync(imageId, _webHostEnvironment.WebRootPath);
                return Json("Success");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        private bool AccommodationExists(int id)
        {
            return _context.Accommodations.Any(e => e.AccommodationId == id);
        }
    }
}

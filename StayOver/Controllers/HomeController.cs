using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StayOver.Data;
using StayOver.Data.Dtos;
using StayOver.Helper;
using StayOver.Models;
using StayOver.Services.Interfaces;
using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StayOver.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccommodationService _accommodationService;
        private readonly IGalleryService _galleryService;

        private readonly StayOverDbContext _context;
        private readonly IMapper _mapper;


        public HomeController(ILogger<HomeController> logger, IAccommodationService accommodationService, IGalleryService galleryService,
            StayOverDbContext context, IMapper mapper)
        {
            _logger = logger;
            _accommodationService = accommodationService;
            _galleryService = galleryService;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> LiveAccommodationPreview(int? pageNumber, string titleSearch, string citySearch, int guestNumber, string selectedCheckIn, string selectedCheckOut)
        {
            ViewBag.controller = "LiveSearch";
            int pageSize = 3;
            var startDate = string.IsNullOrEmpty(selectedCheckIn) ? DateTime.MaxValue : DateTime.Parse(selectedCheckIn.Substring(4, 11));
            var endDate = string.IsNullOrEmpty(selectedCheckOut) ? DateTime.MinValue : DateTime.Parse(selectedCheckOut.Substring(4, 11));

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            ViewBag.userId = userId;
            var result = _accommodationService.GetSearchedAccommodations(titleSearch, citySearch, guestNumber, startDate, endDate);

            return PartialView("_AccommdationsPartialView", await PaginatedList<AccommodationReadDto>.CreateAsync(result, pageNumber ?? 1, pageSize));   
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 3;
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
                ViewBag.userId = userId;

                var result = _accommodationService.GetAccommodations();
                return View(await PaginatedList<AccommodationReadDto>.CreateAsync(result, pageNumber ?? 1, pageSize));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

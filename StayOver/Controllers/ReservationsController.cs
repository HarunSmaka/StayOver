using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StayOver.Data.Dtos;
using StayOver.Helper;
using StayOver.Services.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StayOver.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _service;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int AccommodationId, string checkInDate, string checkOutDate)
        {
            try
            {
                if (AccommodationId == 0)
                {
                    return NotFound();
                }

                string startDateString = checkInDate.Substring(4, 11);
                string endDateString = checkOutDate.Substring(4, 11);
                ViewBag.isVisiter = true;

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var reservationCreateDto = new ReservationCreateDto(DateTime.Parse(startDateString), DateTime.Parse(endDateString),AccommodationId, userId);

                var reservationId = await _service.AddReservationAsync(reservationCreateDto);

                return RedirectToAction("Index", new { id = reservationId });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Index(int id)
        {            
            var result = await _service.GetReservationByIdAsync(id);

            if(result == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            ViewBag.isReviewed = await _service.IsReviewedAsync(id);
            ViewBag.isVisiter = userId == result.Visiter.Id;

            return View(result);
        }

        // GET: My Reservations
        public async Task<IActionResult> MyReservations(string sortOrder, int? pageNumber, string Id = "")
        {
            int pageSize = 3;
            string userId;

            try
            {
                if(string.IsNullOrEmpty(Id))
                {
                    userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                } else
                {
                    userId = Id;
                }

                var result = _service.GetVisitorsReservations(userId);
            
                result = OrderReservations(sortOrder, result);

                return View(await PaginatedList<ReservationReadDto>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));                
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: Visitors Reservations
        public async Task<IActionResult> VisitorsReservations(string sortOrder, int? pageNumber)
        {
            int pageSize = 3;

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result =  _service.GetActiveReservationsToOwner(userId);

                result = OrderReservations(sortOrder, result);

                return View(await PaginatedList<ReservationReadDto>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));

            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> VisitorsReservationsHistory(string sortOrder, int? pageNumber)
        {
            int pageSize = 3;

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = _service.GetReservationsHistoryToOwner(userId);

                result = OrderReservations(sortOrder, result);

                return View(await PaginatedList<ReservationReadDto>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        public async Task<IActionResult> CancelReservation(int Id)
        {  
            try
            {
                var result = await _service.DeleteReservationAsync(Id);

                if (!result)
                {
                    return BadRequest("Reservation could not be canceled");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("MyReservations");
        }

        private IQueryable<ReservationReadDto> OrderReservations(string sortOrder, IQueryable<ReservationReadDto> result)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["CheckInSortParm"] = sortOrder == "CheckIn" ? "checkIn_desc" : "CheckIn";
            ViewData["CheckOutSortParm"] = sortOrder == "CheckOut" ? "checkOut_desc" : "CheckOut";

            result = sortOrder switch
            {
                "title_desc" => result.OrderByDescending(r => r.Accommodation.Title),
                "checkIn_desc" => result.OrderByDescending(r => r.CheckIn),
                "checkOut_desc" => result.OrderByDescending(r => r.CheckOut),
                _ => result.OrderByDescending(r => r.CreatedAt),
            };
            return result;
        }
    }
}


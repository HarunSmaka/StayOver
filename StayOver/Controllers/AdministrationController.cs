using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayOver.Areas.Identity.Data;
using StayOver.Helper;
using StayOver.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace StayOver.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly IAdminService _service;

        public AdministrationController(IAdminService service)
        {
            _service = service;         
        }

        // GET: Accommodations
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 3;
            try
            {
                var result = _service.GetUsers();

                return View(await PaginatedList<ApplicationUser>.CreateAsync(result, pageNumber ?? 1, pageSize));
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StayOver.Areas.Identity.Data;
using StayOver.Data;
using StayOver.Repos.Interfaces;
using System.Linq;

namespace StayOver.Repos
{
    public class AdminRepo : IAdminRepo
    {
        private readonly StayOverDbContext _context;

        public AdminRepo(StayOverDbContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return _context
                .Users
                .Include(u => u.Reservations)
                .Include(u => u.Reviews)
                .Include(u => u.Accommodations)
                .Include("Accommodations.Reservations")
                .OrderBy(u => u.FirstName);
        }   
    }
}


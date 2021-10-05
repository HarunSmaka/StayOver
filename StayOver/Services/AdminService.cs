using StayOver.Areas.Identity.Data;
using StayOver.Repos.Interfaces;
using StayOver.Services.Interfaces;
using System.Linq;

namespace StayOver.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepo _repo;

        public AdminService(IAdminRepo repo)
        {
            _repo = repo;
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return _repo.GetUsers();
        }
    }
}

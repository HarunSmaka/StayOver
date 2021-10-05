using StayOver.Areas.Identity.Data;
using System.Linq;

namespace StayOver.Repos.Interfaces
{
    public interface IAdminRepo
    {
        public IQueryable<ApplicationUser> GetUsers();
    }
}

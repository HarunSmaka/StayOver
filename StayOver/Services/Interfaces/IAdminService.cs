using StayOver.Areas.Identity.Data;
using System.Linq;

namespace StayOver.Services.Interfaces
{
    public interface IAdminService
    {
        public IQueryable<ApplicationUser> GetUsers();
    }
}

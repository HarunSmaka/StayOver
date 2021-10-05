using Microsoft.AspNetCore.Identity;
using StayOver.Areas.Identity.Data.Constants;
using System.Threading.Tasks;

namespace StayOver.Areas.Identity.Data
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }
    }
}

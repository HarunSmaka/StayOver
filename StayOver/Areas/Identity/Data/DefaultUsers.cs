using Microsoft.AspNetCore.Identity;
using StayOver.Areas.Identity.Data.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Areas.Identity.Data
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                FirstName = "Mujo",
                LastName = "Mujić",
                UserName = "mujomujic@gmail.com",
                PhoneNumber = "061123456",
                Email = "mujomujic@gmail.com",
                EmailConfirmed = true
            };
            var defaultUser2 = new ApplicationUser
            {
                FirstName = "Pero",
                LastName = "Peric",
                UserName = "peroperic@gmail.com",
                PhoneNumber = "061321123",
                Email = "peroperic@gmail.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Mujo123.");
                    await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());
                }
            }

            if (userManager.Users.All(u => u.Id != defaultUser2.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Pero123.");
                    await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());
                }
            }
        }
        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Admin123.");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }
            }
        }
    }
}

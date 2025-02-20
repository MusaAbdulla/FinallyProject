using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TourismReserve.Core.Enums;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.BL.Extensions
{
    public static class SeedDataExtensions
    {
        public static void UseUserSeed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var _roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                CreateRoles(_roleManager).Wait();
                CreateUser(userManager).Wait();
            }

        }
        private static async Task CreateRoles(RoleManager<IdentityRole> _roleManager)
        {
            if (await _roleManager.Roles.AnyAsync())
            {
                foreach (Roles item in Enum.GetValues(typeof(Roles)))
                {
                    await _roleManager.CreateAsync(new IdentityRole(item.GetRole()));

                }
            }

        }
        private static async Task CreateUser(UserManager<User> _userManager)
        {
            if (!await _userManager.Users.AnyAsync(u => u.NormalizedUserName == "ADMIN"))
            {
                User user = new User();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                user.FullName = "admin";
                string role = nameof(Roles.Admin);
                await _userManager.CreateAsync(user, "Admin123!");
                await _userManager.AddToRoleAsync(user, role);

            }
        }

    }
}

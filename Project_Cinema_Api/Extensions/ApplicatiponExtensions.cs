using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Project_Cinema_Api.Helpers;

namespace Project_Cinema_Api
{
    public static class ApplicationExtensions
    {
        public static void SeedRoleAndInitialAdmin(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                IdentityInitializer.SeedRolesAsync(roleManager).Wait();
                IdentityInitializer.SeedAdminAsync(userManager).Wait();
            }

        }
    }
}

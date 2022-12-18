using Entites.Entitiy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Seeds
{
    public class RoleSeed 
    {
        public static async Task SeedRolesAsync(RoleManager<Role> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new Role { Name = "Admin" });
           
        }

        public static async Task SeedSuperAdminAsync(UserManager<User> userManager)
        {
            //Seed Default User
            var adminUser = new User
            {
                UserName = "Admin",
                Email = "Admin@admin.com",
                FirstName = "Admin",
                LastName = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            await userManager.CreateAsync(adminUser, "Admin_123");
            await userManager.AddToRoleAsync(adminUser, "Admin");
           
        }
    }

}

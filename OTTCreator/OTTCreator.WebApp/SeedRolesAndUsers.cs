using Microsoft.AspNetCore.Identity;
using OTTCreator.WebApp.Areas.Identity.Data;
using OTTCreator.WebApp.Models;

namespace OTTCreator.WebApp
{
    public static class SeedRolesAndUsers
    {
        public static async Task Initialize(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            var role1 = new Role { };
            role1.Name = "Адміністратор";
            await roleManager.CreateAsync(role1);
            var role2 = new Role { };
            role2.Name = "Користувач";
            await roleManager.CreateAsync(role2);

            var user1 = new User
            {
                UserName = "administrator1@example.com",
                Email = "administrator1@example.com",
                FavoriteContentItemsIDs = new List<int>(),
                CodesAndUse = new Dictionary<Guid,bool>
                {
                    {Guid.NewGuid(), false },
                    {Guid.NewGuid(), false },
                    {Guid.NewGuid(), false },
                    {Guid.NewGuid(), false },
                    {Guid.NewGuid(), false }
                }
            };

            await userManager.CreateAsync(user1, "Aa12345678!");
            await userManager.AddToRoleAsync(user1, "Адміністратор");

            var user2 = new User
            {
                UserName = "user1@example.com",
                Email = "user1@lnu.edu.ua",
                FavoriteContentItemsIDs = new List<int>(),
                CodesAndUse = new Dictionary<Guid, bool>
                {
                    {Guid.NewGuid(), false },
                    {Guid.NewGuid(), false },
                    {Guid.NewGuid(), false },
                    {Guid.NewGuid(), false },
                    {Guid.NewGuid(), false }
                }
            };

            await userManager.CreateAsync(user2, "Bb12345678!");
            await userManager.AddToRoleAsync(user2, "Користувач");
        }
    }
}

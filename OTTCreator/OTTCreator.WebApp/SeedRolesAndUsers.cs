using Microsoft.AspNetCore.Identity;
using OTTCreator.WebApp.Areas.Identity.Data;
using OTTCreator.WebApp.Models;

namespace OTTCreator.WebApp;

public static class SeedRolesAndUsers
{
    public static async Task Initialize(RoleManager<Role> roleManager, UserManager<User> userManager)
    {
        await roleManager.CreateAsync(new Role { Name = "Адміністратор" });
        await roleManager.CreateAsync(new Role { Name = "Клієнт" });

        var user1 = new User
        {
            UserName = "administrator1@ottcreator.com",
            Email = "administrator1@ottcreator.com",
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
            UserName = "user1@ottcreator.com",
            Email = "user1@ottcreator.com",
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
        await userManager.AddToRoleAsync(user2, "Клієнт");
    }
}

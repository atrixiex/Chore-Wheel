using ChoreWheel.Backend.Data.Database;
using ChoreWheel.Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace ChoreWheel.Backend.Data;

public class DataSeeder
{
    public static async Task SeedDatabase(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

        await SeedUserRolesAsync(roleManager);
        await SeedUserAsync(userManager, ChoreWheelConstants.adminUser, ChoreWheelConstants.AdminPassword, ChoreWheelConstants.AdminRoleName);
        await SeedUserAsync(userManager, ChoreWheelConstants.demoUser, ChoreWheelConstants.DemoPassword, ChoreWheelConstants.UserRoleName);
        await SeedUserAsync(userManager, new IdentityUser {
            UserName = "demo2",
            Email = "demo2@test.com",
            EmailConfirmed = true
        }, ChoreWheelConstants.DemoPassword, ChoreWheelConstants.UserRoleName);

        foreach (var user in userManager.Users)
        {
            await SeedChoresAsync(dbContext, user);
        }

        // Shared
        var user1 = await userManager.FindByNameAsync("demo");
        var user2 = await userManager.FindByNameAsync("demo2");
        dbContext.Chore.Add(new Chore { Title = $"Shared - Chore 1", OwnedBy = user1, SharedWith = [user2] });
        await dbContext.SaveChangesAsync();
    }

    private static async Task SeedUserRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        foreach (string role in ChoreWheelConstants.UserRoles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    private static async Task SeedUserAsync(UserManager<IdentityUser> userManager, IdentityUser user, string password, string role = ChoreWheelConstants.UserRoleName)
    {
        // Check if the user already exists and only create if it does not
        if (await userManager.FindByNameAsync(user.UserName ?? throw new InvalidOperationException()) == null)
        {
            // Create the user
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                // Assign the role to the user
                await userManager.AddToRoleAsync(user, role);
            }
            else
            {
                throw new Exception("Failed to create the user: " + string.Join(", ", result.Errors));
            }
        }
    }

    public static async Task SeedChoresAsync(ApplicationDbContext applicationDbContext, IdentityUser user)
    {
        applicationDbContext.Chore.Add(new Chore { Title = $"{user.UserName} - Chore 1", OwnedBy = user });
        applicationDbContext.Chore.Add(new Chore { Title = $"{user.UserName} - Chore 2", OwnedBy = user });
        await applicationDbContext.SaveChangesAsync();
    }

    

    
}

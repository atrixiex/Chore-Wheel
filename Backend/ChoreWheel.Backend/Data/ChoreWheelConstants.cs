using Microsoft.AspNetCore.Identity;

namespace ChoreWheel.Backend.Data;

public static class ChoreWheelConstants
{
    // Roles
    public const string AdminRoleName = "Admin";
    public const string ManagerRoleName = "Manager";
    public const string UserRoleName = "User";

    // Initial admin information
    public const string AdminUsername = "admin";
    public const string AdminPassword = "Chores123!";
    public const string AdminEmail = "admin@test.com";
    public static readonly IdentityUser adminUser = new()
    {
        UserName = AdminUsername,
        Email = AdminEmail,
        EmailConfirmed = true
    };

    // Initial demo information
    public const string DemoUsername = "demo";
    public const string DemoPassword = "Chores123!";
    public const string DemoEmail = "demo@test.com";
    public static readonly IdentityUser demoUser = new()
    {
        UserName = DemoUsername,
        Email = DemoEmail,
        EmailConfirmed = true
    };

    public static readonly string[] UserRoles = [AdminRoleName, ManagerRoleName, UserRoleName];
}

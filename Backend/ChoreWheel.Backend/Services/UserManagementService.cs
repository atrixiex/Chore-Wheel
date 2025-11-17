using ChoreWheel.Backend.DTOs;
using ChoreWheel.Backend.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChoreWheel.Backend.Services;

public class UserManagementService(UserManager<IdentityUser> userManager)
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public async Task<List<UserDto>> GetUsers()
    {
        return await _userManager.Users.Select(user => user.ToDto()).ToListAsync();
    }
}

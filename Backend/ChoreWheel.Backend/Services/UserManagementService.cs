using ChoreWheel.Backend.DTOs;
using ChoreWheel.Backend.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChoreWheel.Backend.Services;

public class UserManagementService(UserManager<IdentityUser> userManager)
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public async Task<List<UserDto>> GetUsers(bool includeActivated)
    {
        if (includeActivated)
        {
            return await _userManager.Users.Select(user => user.ToDto()).ToListAsync();
        }
        return await _userManager.Users.Where(user => user.EmailConfirmed == false).Select(user => user.ToDto()).ToListAsync();
    }

    public async Task<ActionResult> ActivateUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if(user == null)
        {
            return new NotFoundResult();
        }
        if (user.EmailConfirmed)
        {
            return new BadRequestResult();
        }
        user.EmailConfirmed = true;
        await _userManager.UpdateAsync(user);
        return new NoContentResult();
    }

    public async Task<ActionResult> DisableUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return new NotFoundResult();
        }
        if (!user.EmailConfirmed)
        {
            return new BadRequestResult();
        }
        user.EmailConfirmed = false;
        await _userManager.UpdateAsync(user);
        return new NoContentResult();
    }
}

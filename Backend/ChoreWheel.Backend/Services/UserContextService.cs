using ChoreWheel.Backend.Data.Identity;
using Microsoft.AspNetCore.Identity;

namespace ChoreWheel.Backend.Services;

public class UserContextService(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager) : UserContextProvider(httpContextAccessor)
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public IdentityUser? CurrentUser => _userManager.FindByIdAsync(UserId ?? string.Empty).GetAwaiter().GetResult();
}

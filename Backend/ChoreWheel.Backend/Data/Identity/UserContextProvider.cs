using System.Security.Claims;

namespace ChoreWheel.Backend.Data.Identity
{
    public class UserContextProvider(IHttpContextAccessor httpContextAccessor)
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string? UserId =>
            _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public bool IsAdmin => _httpContextAccessor.HttpContext?.User?.IsInRole(ChoreWheelConstants.AdminRoleName) ?? false;
    }
}

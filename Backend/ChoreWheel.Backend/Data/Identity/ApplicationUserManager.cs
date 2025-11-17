using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ChoreWheel.Backend.Data.Identity;

public class ApplicationUserManager(
    IUserStore<IdentityUser> store,
    IOptions<IdentityOptions> optionsAccessor,
    IPasswordHasher<IdentityUser> passwordHasher,
    IEnumerable<IUserValidator<IdentityUser>> userValidators,
    IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    IServiceProvider services,
    ILogger<UserManager<IdentityUser>> logger) : UserManager<IdentityUser>(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
{
    public override async Task<IdentityResult> CreateAsync(IdentityUser user, string password)
    {
        user.EmailConfirmed = false;
        var result = await base.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await AddToRoleAsync(user, ChoreWheelConstants.UserRoleName);
        }
        return result;
    }

}

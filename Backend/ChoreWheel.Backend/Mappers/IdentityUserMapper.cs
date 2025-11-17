using ChoreWheel.Backend.Data.Identity;
using ChoreWheel.Backend.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ChoreWheel.Backend.Mappers;

public static class IdentityUserMapper
{
    extension(IdentityUser user)
    {
        public UserDto ToDto()
        {
            return new UserDto { Id = user.Id, UserName = user.UserName ?? string.Empty };
        }
    }
}
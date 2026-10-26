using Dating.Api.Entities;
using Dating.Api.Features.Account;
using Dating.Api.Infrastructure.Data.Authentication;

namespace Dating.Api.Extensions;

public static class AppUserExtensions
{
    public static UserDTO ToDto(this AppUser user,ITokenService tokenService)
    {

        return new UserDTO(user.Id, user.Email, user.DisplayName, tokenService.CreateToken(user),null);
    }
}

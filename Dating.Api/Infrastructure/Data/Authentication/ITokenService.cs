using Dating.Api.Entities;

namespace Dating.Api.Infrastructure.Data.Authentication;
public interface ITokenService
{
    string CreateToken(AppUser user);
}

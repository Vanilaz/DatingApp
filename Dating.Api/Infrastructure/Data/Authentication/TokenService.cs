using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dating.Api.Entities;
using Humanizer;
using Microsoft.IdentityModel.Tokens;

namespace Dating.Api.Infrastructure.Data.Authentication;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        var tokenKey = config["TokenKey"] ?? throw new Exception("Cannot get token Key");

        if(tokenKey.Length < 64) throw new Exception("Your token keys needs to be>= 64 characters");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        

        var claims = new List<Claim>()
        {
          new(ClaimTypes.Email,user.Email),
          new(ClaimTypes.NameIdentifier,user.Id),
        };

        var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject=new ClaimsIdentity(claims),
            Expires=DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler=new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}

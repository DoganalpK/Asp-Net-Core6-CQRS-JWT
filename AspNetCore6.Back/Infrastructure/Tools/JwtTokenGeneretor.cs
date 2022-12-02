using AspNetCore6.Back.Core.Application.Dtos.UserDto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AspNetCore6.Back.Infrastructure.Tools
{
    public class JwtTokenGeneretor
    {
        public static JwtTokenResponse GenerateToken(CheckUserResponseDto dto)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            claims.Add(new Claim(ClaimTypes.Name, dto.Username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenSettings.ValidIssuer,
                audience: JwtTokenSettings.ValidAudience,
                claims: null,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(JwtTokenSettings.Expire)
            );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new JwtTokenResponse(handler.WriteToken(token));
        }
    }
}

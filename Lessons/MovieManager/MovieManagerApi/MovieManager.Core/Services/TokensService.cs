using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieManager.Core.Configurations;
using MovieManager.Core.Interfaces;

namespace MovieManager.Core.Services;
public class TokensService(IOptions<JwtConfiguration> jwtConfig) : ITokensService
{
    public (string token, DateTime expiration) GenerateAccessToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = Encoding.UTF8.GetBytes(jwtConfig.Value.SecretKey);
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, "userId"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "User") ,
            new Claim(JwtRegisteredClaimNames.Iss, jwtConfig.Value.Issuer)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(jwtConfig.Value.ExpirationInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature),
            Audience = jwtConfig.Value.Audience,
            Issuer = jwtConfig.Value.Issuer,
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return (tokenHandler.WriteToken(token), tokenDescriptor.Expires.Value);
    }
}

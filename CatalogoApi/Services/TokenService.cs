using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CatalogoApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace CatalogoApi.Services;

public class TokenService : ITokenService
{

    public string GerarToken(string key, string issuer, string audience, UserModel user)
    {
        var claims = new[]
        {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(
            ClaimTypes.NameIdentifier,
            Guid.NewGuid().ToString()
            )
    };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(20),  // Usar UtcNow em vez de Now
            signingCredentials: credentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);  // Adicione esta linha para retornar o token
    }
}


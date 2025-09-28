using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenBaseNET.Domain.Interfaces.Services;


namespace OpenBaseNET.Application.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public Task<string> GenerateToken(string apiId)
    {
        
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"] ?? string.Empty);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, apiId),
            ]),
            // Expiração do Token
            Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(configuration["Jwt:ExpiryHours"])),
            // Emissor e Audiência
            Issuer = configuration["Jwt:Issuer"],
            Audience = configuration["Jwt:Audience"],
            // Credenciais de assinatura
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}

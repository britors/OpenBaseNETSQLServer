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
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"] ?? throw new ApplicationException("JWT keys is not configured"));

        var securityKey = new SymmetricSecurityKey(key);

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var expiryHours = configuration["Jwt:ExpiryHours"] ?? "1";

        var sectoken = new JwtSecurityToken(
                configuration["Jwt:Issuer"] ?? "",
                configuration["Jwt:Audience"] ?? "",
                [
                    new Claim(ClaimTypes.Name, apiId)
                ],
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(expiryHours)),
                signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(sectoken);
        return Task.FromResult(token);
    }
}

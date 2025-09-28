namespace OpenBaseNET.Domain.Interfaces.Services;

public interface ITokenService
{
    Task<string> GenerateToken(string apiId);
}

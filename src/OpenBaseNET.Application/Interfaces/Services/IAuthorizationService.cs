using OpenBaseNET.Application.DTOs.Base.Request;
using OpenBaseNET.Application.Interfaces.Base;

namespace OpenBaseNET.Application.Interfaces.Services;

public interface IAuthorizationService : IApplicationService
{
    Task<string> Authenticate(AuthenticationRequest request, CancellationToken cancellationToken);
}
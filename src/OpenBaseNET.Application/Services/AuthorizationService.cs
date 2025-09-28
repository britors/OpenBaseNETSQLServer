using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Base.Request;
using OpenBaseNET.Application.Features.Authenticate;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Application.Services;

public class AuthorizationService (IMediator mediator, IMapper mapper) : IAuthorizationService
{
    public async Task<string> Authenticate(AuthenticationRequest request, CancellationToken cancellationToken = default)
    {
        var query = mapper.Map<AuthenticateCommand>(request);
        return await mediator.Send(query, cancellationToken);
    }
}
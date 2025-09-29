using MediatR;
using Microsoft.Extensions.Configuration;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.Authenticate;

public class AuthenticateCommandHandler(ITokenService tokenService, IConfiguration configuration)
    : IRequestHandler<AuthenticateCommand, string>
{
    public async Task<string> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        if (request.ApiId == configuration["Jwt:Id"] && request.Password == configuration["Jwt:Secret"])
            return await tokenService.GenerateToken(request.ApiId);

        throw new UnauthorizedAccessException();
    }
}
using MediatR;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.Authenticate;

public class AuthenticateCommandHandler(ITokenService tokenService)
    : IRequestHandler<AuthenticateCommand, string>
{
    public async Task<string> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.ApiId == "API_PRINCIPAL" && request.Password == "SenhaForte123")
            {
                return await tokenService.GenerateToken(request.ApiId);
            }

            throw new UnauthorizedAccessException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception(e.Message);
        }
    }
}
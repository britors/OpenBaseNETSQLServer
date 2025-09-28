using MediatR;

namespace OpenBaseNET.Application.Features.Authenticate;

public class AuthenticateCommand: IRequest<string>
{
    public string ApiId { get; set; } =  string.Empty;
    public string Password { get; set; } = string.Empty;
}
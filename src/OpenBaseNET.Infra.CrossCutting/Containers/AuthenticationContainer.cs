using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.Services;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class AuthenticationContainer
{
    internal static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITokenService, TokenService>(); 
    }
}
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.Logger;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class LoggerContainer
{
    internal static void RegisterServices(IServiceCollection services)
    {
        services.AddLogger();
    }
}
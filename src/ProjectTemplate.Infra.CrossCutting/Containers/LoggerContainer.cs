using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Infra.Logger;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class LoggerContainer
{
    internal static void RegisterServices(IServiceCollection services)
    {
        services.AddLogger();
    }
}
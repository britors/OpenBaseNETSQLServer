using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Domain.Context;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class ContextContainer
{
    internal static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<SessionContext>();
    }
}
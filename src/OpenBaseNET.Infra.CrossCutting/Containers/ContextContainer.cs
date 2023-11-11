using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Domain.Context;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class ContextContainer
{
    internal static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<SessionContext>();
    }
}
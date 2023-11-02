using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Domain.Context;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class ContextContainer
{
    internal static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<SessionContext>();
    }
}
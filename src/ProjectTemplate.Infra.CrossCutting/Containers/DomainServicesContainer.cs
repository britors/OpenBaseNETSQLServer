using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Domain.Interfaces.Services;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class DomainServicesContainer
{
    internal static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IClienteDomainService, IClienteDomainService>();
    }
}
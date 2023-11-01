using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Application.Services;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class ApplicationServicesContainer
{
    internal static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
    }
}
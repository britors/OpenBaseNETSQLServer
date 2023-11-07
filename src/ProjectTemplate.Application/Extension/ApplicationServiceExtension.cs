using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Interfaces.Extension;
using System.Reflection;

namespace ProjectTemplate.Application.Extension;

public static class ApplicationServiceExtension
{
    public static void AddApplicationServices(this IServiceCollection services, Assembly assembly)
    {
        var appServices = assembly.GetTypes().Where(
            type =>
                type is { IsClass: true, IsAbstract: false }
                && type.IsAssignableTo(typeof(IApplicationService)));

        foreach (var appService in appServices)
        {
            var implementedInterface = appService
                .GetInterfaces()
                .First(x => x is { IsTypeDefinition: true, Namespace: not null }
                            && x.Namespace.Contains("Application.Interfaces.Services"));

            services.AddScoped(implementedInterface, appService);
        }
    }
}
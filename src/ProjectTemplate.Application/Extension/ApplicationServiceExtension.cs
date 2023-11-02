using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Interfaces.Extension;
using System.Reflection;

namespace ProjectTemplate.Application.Extension;

public static class ApplicationServiceExtension
{
    public static void AddApplicationServices(this IServiceCollection services, Assembly assembly)
    {
        var appServices = assembly.GetTypes().Where(services =>
            services.IsClass
            && !services.IsAbstract
            && services.IsAssignableTo(typeof(IApplicationService)));

        foreach (var appService in appServices)
        {
            var implementedInterface = appService
                        .GetInterfaces()
                        .Where(x => x.IsTypeDefinition
                                && x.Namespace is not null
                                && x.Namespace.Contains("Application.Interfaces.Services"))
                        .FirstOrDefault();

            if (implementedInterface is not null)
                services.AddScoped(implementedInterface, appService);
        }
    }
}
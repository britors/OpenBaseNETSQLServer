using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.Interfaces.Base;
using System.Reflection;

namespace OpenBaseNET.Application.Extension;

public static class ApplicationServiceExtension
{
    public static void AddApplicationServices(
        this IServiceCollection services,
        Assembly assembly,
        string namespaceToScan)
    {
        ArgumentNullException.ThrowIfNull(namespaceToScan);
        ArgumentNullException.ThrowIfNull(assembly);

        var appServices = assembly.GetTypes().Where(
            type =>
                type is { IsClass: true, IsAbstract: false }
                && type.IsAssignableTo(typeof(IApplicationService)));

        foreach (var appService in appServices)
        {
            var implementedInterface = appService
                .GetInterfaces()
                .First(x => x is { IsTypeDefinition: true, Namespace: not null }
                            && x.Namespace.Equals(namespaceToScan));

            services.AddScoped(implementedInterface, appService);
        }
    }
}
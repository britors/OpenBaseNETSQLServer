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
                .Where(x => namespaceToScan.Equals(x.Namespace))
                .Single();

            services.AddScoped(implementedInterface, appService);
        }
    }
}
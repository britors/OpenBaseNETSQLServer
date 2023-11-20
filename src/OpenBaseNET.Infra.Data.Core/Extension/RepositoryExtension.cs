using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OpenBaseNET.Infra.Data.Core.Extension;

public static class RepositoryExtension
{
    public static void AddRepositories(
        this IServiceCollection services,
        Assembly assembly,
        string namespaceToScan)
    {
        ArgumentNullException.ThrowIfNull(namespaceToScan);
        ArgumentNullException.ThrowIfNull(assembly);

        var appServices = assembly.GetTypes().Where(type =>
            type is { IsClass: true, IsAbstract: false }
            && type.IsAssignableTo(typeof(IDataRepository)));

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
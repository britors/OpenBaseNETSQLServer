using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Infra.Data.Mssql;
using System.Reflection;

namespace ProjectTemplate.Infra.Data.Core;

public static class RepositoryExtension
{
    public static void AddRepositories(this IServiceCollection services, Assembly assembly)
    {
        var appServices = assembly.GetTypes().Where(type =>
            type is { IsClass: true, IsAbstract: false }
            && type.IsAssignableTo(typeof(IDataRepository)));

        foreach (var appService in appServices)
        {
#pragma warning disable S2971 // "IEnumerable" LINQs should be simplified
            var implementedInterface = appService
                .GetInterfaces()
                .First(x => x is { IsTypeDefinition: true, Namespace: not null }
                            && x.Namespace.Contains("Domain.Interfaces.Repositories"));
#pragma warning restore S2971 // "IEnumerable" LINQs should be simplified

            services.AddScoped(implementedInterface, appService);
        }
    }
}
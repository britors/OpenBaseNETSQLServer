using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Infra.Data.Mssql;
using System.Reflection;

namespace ProjectTemplate.Infra.Data.Core;

public static class RepositoryExtension
{
    public static void AddRepositories(this IServiceCollection services, Assembly assembly)
    {
        var appServices = assembly.GetTypes().Where(services =>
            services.IsClass
            && !services.IsAbstract
            && services.IsAssignableTo(typeof(IDataRepository)));

        foreach (var appService in appServices)
        {
#pragma warning disable S2971 // "IEnumerable" LINQs should be simplified
            var implementedInterface = appService
                        .GetInterfaces()
                        .Where(x => x.IsTypeDefinition
                                && x.Namespace is not null
                                && x.Namespace.Contains("Domain.Interfaces.Repositories"))
                        .FirstOrDefault();
#pragma warning restore S2971 // "IEnumerable" LINQs should be simplified

            if (implementedInterface is not null)
                services.AddScoped(implementedInterface, appService);
        }
    }
}
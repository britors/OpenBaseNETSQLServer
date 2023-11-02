using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Domain.Interfaces.Repositories;
using System.Reflection;

namespace ProjectTemplate.Infra.Data.Core;

public static class RepositoryExtension
{
    public static void AddRepositories(this IServiceCollection services, Assembly assembly)
    {
        var appServices = assembly.GetTypes().Where(services =>
            services.IsClass
            && !services.IsAbstract
            && services.IsAssignableTo(typeof(IRepositoryBase<>)));

        foreach (var appService in appServices)
        {
            var implementedInterface = appService
                        .GetInterfaces()
                        .Where(x => x.IsTypeDefinition)
                        .FirstOrDefault();

            if (implementedInterface is not null)
                services.AddScoped(implementedInterface, appService);
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Reflection;

namespace ProjectTemplate.Domain.Extension;

public static class DomainServiceExtension
{
    public static void AddDomainServices(this IServiceCollection services, Assembly assembly)
    {
        var appServices = assembly.GetTypes().Where(services =>
            services.IsClass
            && !services.IsAbstract
            && services.IsAssignableTo(typeof(IDomainService)));

        foreach (var appService in appServices)
        {
            var implementedInterface = appService
                        .GetInterfaces()
                        .Where(x => x.IsTypeDefinition
                                && x.Namespace is not null
                                && x.Namespace.Contains("Domain.Interfaces.Services"))
                        .FirstOrDefault();

            if (implementedInterface is not null)
                services.AddScoped(implementedInterface, appService);
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Reflection;

namespace ProjectTemplate.Domain.Extension;

public static class DomainServiceExtension
{
    public static void AddDomainServices(this IServiceCollection services, Assembly assembly)
    {
        var domainServices = assembly.GetTypes()
             .Where(type =>
             {
                 return type.GetInterfaces().Any(interfaceType =>
                                  interfaceType.IsGenericType &&
                                  interfaceType.GetGenericTypeDefinition() == typeof(IDomainService<,>))
                 && !type.IsAbstract
                 && type.IsClass;
             })
             .ToList();

        foreach (var appService in domainServices)
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
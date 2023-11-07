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
#pragma warning disable S6605 // Collection-specific "Exists" method should be used instead of the "Any" extension
                 return type.GetInterfaces().Any(interfaceType =>
                                  interfaceType.IsGenericType &&
                                  interfaceType.GetGenericTypeDefinition() == typeof(IDomainService<,>))
                 && !type.IsAbstract
                 && type.IsClass;
#pragma warning restore S6605 // Collection-specific "Exists" method should be used instead of the "Any" extension
             })
             .ToList();

        foreach (var appService in domainServices)
        {
            var implementedInterface = appService
                        .GetInterfaces()
                        .FirstOrDefault(x => x.IsTypeDefinition
                                && x.Namespace is not null
                                && x.Namespace.Contains("Domain.Interfaces.Services"));

            if (implementedInterface is not null)
                services.AddScoped(implementedInterface, appService);
        }
    }
}
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
                        && type is { IsAbstract: false, IsClass: true };
#pragma warning restore S6605 // Collection-specific "Exists" method should be used instead of the "Any" extension
             })
             .ToList();

        foreach (var appService in domainServices)
        {
            var implementedInterface = appService
                        .GetInterfaces()
                        .First(x => x is { IsTypeDefinition: true, Namespace: not null }
                                    && x.Namespace.Contains("Domain.Interfaces.Services"));

            services.AddScoped(implementedInterface, appService);
        }
    }
}
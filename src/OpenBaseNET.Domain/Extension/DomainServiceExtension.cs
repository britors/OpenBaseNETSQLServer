using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Domain.Extension;

public static class DomainServiceExtension
{
    public static void AddDomainServices(this IServiceCollection services, Assembly assembly)
    {
        var domainServices = assembly.GetTypes()
            .Where(type =>
            {
                return type.GetInterfaces()
                           .ToList()
                           .Exists(interfaceType =>
                               interfaceType.IsGenericType &&
                               interfaceType.GetGenericTypeDefinition() == typeof(IDomainService<,>))
                       && type is { IsAbstract: false, IsClass: true };
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
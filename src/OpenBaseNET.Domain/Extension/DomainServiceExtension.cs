using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Domain.Interfaces.Services;
using System.Reflection;

namespace OpenBaseNET.Domain.Extension;

public static class DomainServiceExtension
{
    public static void AddDomainServices(
        this IServiceCollection services,
        Assembly assembly,
        string domainServiceNamespace)
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
                .Single(x => !x.IsConstructedGenericType && domainServiceNamespace.Equals(x.Namespace));

            services.AddScoped(implementedInterface, appService);
        }
    }
}
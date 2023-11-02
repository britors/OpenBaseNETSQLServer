using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProjectTemplate.Infra.Mediator;

public static class MediatrExtension
{
    public static void AddMediatRApi(this IServiceCollection services, Assembly assembly)
    {
        var requests = assembly.GetTypes()
             .Where(type =>
             {
                 return type.GetInterfaces().Any(interfaceType =>
                                  interfaceType.IsGenericType &&
                                  interfaceType.GetGenericTypeDefinition() == typeof(IRequest<>));
             })
             .ToList();

        foreach (var request in requests)
            services.AddMediatR(request);
    }
}
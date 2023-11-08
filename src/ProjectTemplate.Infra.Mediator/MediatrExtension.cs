using FluentValidation;
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
#pragma warning disable S6605 // Collection-specific "Exists" method should be used instead of the "Any" extension
                 return type.GetInterfaces().Any(interfaceType =>
                                  interfaceType.IsGenericType &&
                                  interfaceType.GetGenericTypeDefinition() == typeof(IRequest<>));
#pragma warning restore S6605 // Collection-specific "Exists" method should be used instead of the "Any" extension
             })
             .ToList();

        foreach (var request in requests)
            services.AddMediatR(cfg 
                => cfg.RegisterServicesFromAssembly(request.Assembly));

        services.AddValidatorsFromAssembly(assembly);
    }
}
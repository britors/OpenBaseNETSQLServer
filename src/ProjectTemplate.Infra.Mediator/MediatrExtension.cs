using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectTemplate.Infra.Mediator;

public static class MediatrExtension
{
    public static void AddMediatRApi(this IServiceCollection services, Assembly assembly)
    {
        var requests = assembly.GetTypes()
            .Where(type =>
            {
                return type.GetInterfaces().ToList().Exists(interfaceType =>
                    interfaceType.IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == typeof(IRequest<>));
            })
            .ToList();

        foreach (var request in requests)
            services.AddMediatR(cfg
                => cfg.RegisterServicesFromAssembly(request.Assembly));

        services.AddValidatorsFromAssembly(assembly);
    }
}
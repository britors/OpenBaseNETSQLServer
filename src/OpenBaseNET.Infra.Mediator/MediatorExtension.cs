using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OpenBaseNET.Infra.Mediator;

public static class MediatorExtension
{
    public static void AddMediatorApi(this IServiceCollection services, Assembly assembly)
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
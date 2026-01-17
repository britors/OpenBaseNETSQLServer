/*
 * Name: MediatorExtension
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Extension Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Classe de extensão para configuração do Mediator.
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do MediatorExtension                |
 * |--------------------------------------------------------------|
 */

using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OpenBaseNET.Infra.Mediator;

public static class MediatorExtension
{
    public static void AddMediatorApi(this IServiceCollection services, IConfiguration configuration,  Assembly assembly)
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
            services.AddMediatR(cfg =>
            {
                cfg.LicenseKey = configuration.GetSection("Mediator:LicenseKey").Value ?? string.Empty;
                cfg.RegisterServicesFromAssembly(request.Assembly);
            });

        services.AddValidatorsFromAssembly(assembly);
    }
}
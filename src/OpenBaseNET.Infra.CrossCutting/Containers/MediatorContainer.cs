/*
 * Name: MediatorContainer
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Execução do Container de Injeção de Dependência do Mediator.
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do MediatorContainer                |
 * |--------------------------------------------------------------|
 */

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.Pipelines;
using OpenBaseNET.Infra.Mediator;
using System.Reflection;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class MediatorContainer
{
    internal static void RegisterServices(IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {
        services.AddMediatorApi(configuration, assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(LoggingBehaviour<,>));
    }
}
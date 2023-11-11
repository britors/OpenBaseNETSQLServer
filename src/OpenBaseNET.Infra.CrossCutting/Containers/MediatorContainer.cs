using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.Pipelines;
using OpenBaseNET.Infra.Mediator;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class MediatorContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddMediatRApi(assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(LoggingBehaviour<,>));
    }
}
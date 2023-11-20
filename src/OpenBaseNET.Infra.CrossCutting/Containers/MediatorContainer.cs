using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.Pipelines;
using OpenBaseNET.Infra.Mediator;
using System.Reflection;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class MediatorContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddMediatorApi(assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(LoggingBehaviour<,>));
    }
}
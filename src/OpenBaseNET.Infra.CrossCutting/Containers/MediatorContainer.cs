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
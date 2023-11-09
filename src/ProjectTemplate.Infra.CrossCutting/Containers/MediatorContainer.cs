using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Pipelines;
using ProjectTemplate.Infra.Mediator;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

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
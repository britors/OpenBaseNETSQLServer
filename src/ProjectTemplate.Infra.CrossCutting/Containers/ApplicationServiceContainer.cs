using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.Extension;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class ApplicationServiceContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddApplicationServices(assembly);
    }
}
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.Extension;
using System.Reflection;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class ApplicationServiceContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddApplicationServices(assembly, "OpenBaseNET.Application.Interfaces.Services");
    }
}
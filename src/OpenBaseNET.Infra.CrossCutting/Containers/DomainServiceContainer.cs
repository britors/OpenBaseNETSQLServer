using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Domain.Extension;
using System.Reflection;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class DomainServiceContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddDomainServices(assembly, "OpenBaseNET.Domain.Interfaces.Services");
    }
}
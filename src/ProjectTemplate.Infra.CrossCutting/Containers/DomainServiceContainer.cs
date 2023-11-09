using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Domain.Extension;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class DomainServiceContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddDomainServices(assembly);
    }
}
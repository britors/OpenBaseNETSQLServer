using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Infra.Data.Core;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class RepositoriesContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddRepositories(assembly);
    }
}
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.Data.Core;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class RepositoriesContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddRepositories(assembly);
    }
}
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.Data.Core.Extension;
using System.Reflection;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class RepositoriesContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddRepositories(assembly, "OpenBaseNET.Domain.Interfaces.Repositories");
    }
}
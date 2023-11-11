using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.AutoMapper;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class AutoMapperContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddAutoMapperApi(assembly);
    }
}
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.AutoMapper;
using System.Reflection;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class AutoMapperContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddAutoMapperApi(assembly);
    }
}
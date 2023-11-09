using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Infra.AutoMapper;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class AutoMapperContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddAutoMapperApi(assembly);
    }
}
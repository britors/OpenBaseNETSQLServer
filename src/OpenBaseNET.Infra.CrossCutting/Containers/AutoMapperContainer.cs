using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.AutoMapper;
using System.Reflection;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class AutoMapperContainer
{
    internal static void RegisterServices(IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {
        services.AddAutoMapperApi(configuration, assembly);
    }
}
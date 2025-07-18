using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OpenBaseNET.Infra.AutoMapper;

public static class AutoMapperExtension
{
    public static void AddAutoMapperApi(this IServiceCollection services, Assembly assembly)
    {
        _ = services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(assembly);
            cfg.AllowNullDestinationValues = true;
            cfg.AllowNullCollections = true;
        });
    }
}
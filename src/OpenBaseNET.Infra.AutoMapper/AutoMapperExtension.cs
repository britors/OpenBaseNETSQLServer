using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace OpenBaseNET.Infra.AutoMapper;

public static class AutoMapperExtension
{
    public static void AddAutoMapperApi(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {
        _ = services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(assembly);
            cfg.AllowNullDestinationValues = true;
            cfg.AllowNullCollections = true;
            cfg.LicenseKey = configuration.GetSection("AutoMapper:LicenseKey").Value ?? string.Empty;
        });
    }
}
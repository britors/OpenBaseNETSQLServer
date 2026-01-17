
/*
 * Name: AutoMapperExtension
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Extension
 * Create At:   01/17/2026
 * Last Update: 01/17/2026
 * Description:
 *      Adicionar extensão do AutoMapper para configuração na API
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 01/17/2026     | Criação da extensão AutoMapperExtension     |
 * |--------------------------------------------------------------|
 */

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
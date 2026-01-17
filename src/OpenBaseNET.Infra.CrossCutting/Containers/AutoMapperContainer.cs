/*
 * Name: AutoMapperContainer
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Execução do registro dos serviços de AutoMapper.
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do AutoMapperContainer             |
 * |--------------------------------------------------------------|
 */

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
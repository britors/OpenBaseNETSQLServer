/*
 * Name: ApplicationServiceContainer
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Execução do registro dos serviços de Application Service.
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do ApplicationServiceContainer      |
 * |--------------------------------------------------------------|
 */
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.Extension;
using System.Reflection;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class ApplicationServiceContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddApplicationServices(assembly, "OpenBaseNET.Application.Interfaces.Services");
    }
}
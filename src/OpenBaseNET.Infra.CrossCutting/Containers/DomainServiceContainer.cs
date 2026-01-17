/*
 * Name: DomainServiceContainer
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Execução do registro dos serviços de Domain Service.
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do DomainServiceContainer           |
 * |--------------------------------------------------------------|
 */

using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Domain.Extension;
using System.Reflection;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class DomainServiceContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddDomainServices(assembly, "OpenBaseNET.Domain.Interfaces.Services");
    }
}
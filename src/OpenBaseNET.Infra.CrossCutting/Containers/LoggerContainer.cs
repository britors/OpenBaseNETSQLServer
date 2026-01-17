/*
 * Name: LoggerContainer
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Execução do registro dos serviços de Logger.
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do LoggerContainer                  |
 * |--------------------------------------------------------------|
 */

using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.Logger;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class LoggerContainer
{
    internal static void RegisterServices(IServiceCollection services)
    {
        services.AddLogger();
    }
}
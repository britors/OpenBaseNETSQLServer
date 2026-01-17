/*
 * Name: LoggerExtension
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Extension Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Classe de extensão para configuração do Logger Serilog.
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do LoggerExtension                  |
 * |--------------------------------------------------------------|
 */

using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace OpenBaseNET.Infra.Logger;

public static class LoggerExtension
{

    public static void AddLogger(this IServiceCollection serviceCollection)
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel
            .Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .CreateLogger();

        serviceCollection.AddLogging(builder => { builder.AddSerilog(); });
    }
}
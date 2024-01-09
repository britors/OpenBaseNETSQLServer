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
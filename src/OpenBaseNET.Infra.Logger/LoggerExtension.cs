using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.Settings.ConnectionStrings;
using Serilog;
using Serilog.Events;

namespace OpenBaseNET.Infra.Logger;

public static class LoggerExtension
{

    public static void AddLogger(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var mongoUrl = configuration.GetConnectionString(OneBaseConnectionStrings.OpenBaseMongoDb);
        if (mongoUrl is null) return;
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel
            .Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.MongoDB(mongoUrl, "openbase")
            .CreateLogger();

        serviceCollection.AddLogging(builder => { builder.AddSerilog(); });
    }
}
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
        var MongoUrl = configuration.GetConnectionString(OneBaseConnectionStrings.OneBaseMongoDb);
        if (MongoUrl is not null)
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel
                .Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.MongoDB(MongoUrl, "onehome")
                .CreateLogger();

            serviceCollection.AddLogging(builder => { builder.AddSerilog(); });
        }
    }
}
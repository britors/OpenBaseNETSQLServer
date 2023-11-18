using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.ConnectionStrings;
using OpenBaseNET.Infra.Uow;
using OpenBaseNET.Infra.Uow.Interfaces;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class DatabaseContainer
{
    internal static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbConnection>(_ =>
            new SqlConnection(configuration.GetConnectionString(OneBaseConnectionStrings.OneBaseSqlServer)));
        services.AddScoped<DbSession>();
        services.AddScoped<OneBaseDataBaseContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
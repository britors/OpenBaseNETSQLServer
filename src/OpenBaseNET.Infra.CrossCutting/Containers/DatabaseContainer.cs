using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.Mssql.Uow;
using OpenBaseNET.Infra.Mssql.Uow.Interfaces;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class DatabaseContainer
{
    internal static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbConnection>(_ =>
            new SqlConnection(configuration.GetConnectionString("SqlServer")));
        services.AddScoped<DbSession>();
        services.AddScoped<ProjectDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
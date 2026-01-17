/*
 * Name: DatabaseContainer
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Execução do registro dos serviços de Database.
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do DatabaseContainer                 |
 * |--------------------------------------------------------------|
 */

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.Data.Context;
using OpenBaseNET.Infra.Settings.ConnectionStrings;
using OpenBaseNET.Infra.Uow;
using OpenBaseNET.Infra.Uow.Interfaces;
using System.Data.Common;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class DatabaseContainer
{
    internal static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbConnection>(_ =>
            new SqlConnection(configuration.GetConnectionString(OneBaseConnectionStrings.OpenBaseSqlServer)));
        services.AddScoped<DbSession>();
        services.AddScoped<OneBaseDataBaseContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
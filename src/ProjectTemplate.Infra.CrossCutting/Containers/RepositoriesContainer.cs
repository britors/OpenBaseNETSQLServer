using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Infra.Data.Mssql.Repositories;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class RepositoriesContainer
{
    internal static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
    }
}
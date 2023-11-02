using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Services;
using ProjectTemplate.Domain.Interfaces.Services;
using ProjectTemplate.Domain.Services;
using ProjectTemplate.Infra.AutoMapper;
using ProjectTemplate.Infra.CrossCutting.Containers;
using ProjectTemplate.Infra.Data.Core;
using ProjectTemplate.Infra.Data.Mssql;
using ProjectTemplate.Infra.Mediator;

namespace ProjectTemplate.Infra.CrossCutting;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapperApi(typeof(IApplicationService).Assembly);
        ConfigurationsContainer.RegisterServices(services, configuration);
        ContextContainer.RegisterServices(services);
        DatabaseContainer.RegisterServices(services, configuration);
        services.AddRepositories(typeof(IDataRepository).Assembly);
        services.AddDomainServices(typeof(IDomainService).Assembly);
        services.AddMediatRApi(typeof(IApplicationService).Assembly);
        services.AddApplicationServices(typeof(IApplicationService).Assembly);
    }
}
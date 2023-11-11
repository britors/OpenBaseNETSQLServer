using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.Interfaces.Extension;
using OpenBaseNET.Domain.Interfaces.Services;
using ProjectTemplate.Infra.CrossCutting.Containers;
using ProjectTemplate.Infra.Data.Mssql;

namespace ProjectTemplate.Infra.CrossCutting;

public static class NativeInjectorBootStrapper
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        AutoMapperContainer.RegisterServices(services, typeof(IApplicationService).Assembly);
        ConfigurationsContainer.RegisterServices(services, configuration);
        ContextContainer.RegisterServices(services);
        DatabaseContainer.RegisterServices(services, configuration);
        RepositoriesContainer.RegisterServices(services, typeof(IDataRepository).Assembly);
        DomainServiceContainer.RegisterServices(services, typeof(IDomainService<,>).Assembly);
        MediatorContainer.RegisterServices(services, typeof(IApplicationService).Assembly);
        ApplicationServiceContainer.RegisterServices(services, typeof(IApplicationService).Assembly);
        LoggerContainer.RegisterServices(services);
    }
}
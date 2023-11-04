using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Extension;
using ProjectTemplate.Application.Interfaces.Extension;
using ProjectTemplate.Application.Pipelines;
using ProjectTemplate.Domain.Extension;
using ProjectTemplate.Domain.Interfaces.Services;
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
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        services.AddApplicationServices(typeof(IApplicationService).Assembly);
    }
}
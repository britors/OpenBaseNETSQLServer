using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application;
using ProjectTemplate.Infra.CrossCutting.Containers;
using ProjectTemplate.Infra.Mediator;

namespace ProjectTemplate.Infra.CrossCutting;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        AutoMapperContainer.RegisterMappings(services);
        ConfigurationsContainer.RegisterServices(services, configuration);
        ContextContainer.RegisterServices(services);
        DatabaseContainer.RegisterServices(services, configuration);
        RepositoriesContainer.RegisterServices(services);
        DomainServicesContainer.RegisterServices(services);
        services.AddMediatRApi(typeof(IApplication).Assembly);
        ApplicationServicesContainer.RegisterServices(services);
    }
}
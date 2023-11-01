using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Infra.CrossCutting.Containers;

namespace ProjectTemplate.Infra.CrossCutting;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        AutoMapperContainer.RegisterMappings(services);
        ConfigurationsContainer.RegisterServices(services, configuration);
        ServicesContainer.RegisterServices(services);
        DatabaseContainer.RegisterServices(services, configuration);
        RepositoriesContainer.RegisterServices(services);
    }
}
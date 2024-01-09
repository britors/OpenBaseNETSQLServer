using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Application.Interfaces.Base;
using OpenBaseNET.Domain.Interfaces.Services;
using OpenBaseNET.Infra.CrossCutting.Containers;
using OpenBaseNET.Infra.Data;

namespace OpenBaseNET.Infra.CrossCutting;

public static class NativeInjectorBootStrap
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        AutoMapperContainer.RegisterServices(services, typeof(IApplicationService).Assembly);
        DatabaseContainer.RegisterServices(services, configuration);
        RepositoriesContainer.RegisterServices(services, typeof(IDataRepository).Assembly);
        DomainServiceContainer.RegisterServices(services, typeof(IDomainService<,>).Assembly);
        MediatorContainer.RegisterServices(services, typeof(IApplicationService).Assembly);
        ApplicationServiceContainer.RegisterServices(services, typeof(IApplicationService).Assembly);
        LoggerContainer.RegisterServices(services);
    }
}
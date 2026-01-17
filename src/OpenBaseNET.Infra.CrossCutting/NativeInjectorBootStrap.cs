/*
 * Name: NativeInjectorBootStrap
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *   Registrar serviços de injeção de dependência na aplicação
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 01/17/2026     | Criação da classe NativeInjectorBootStrap   |
 * |--------------------------------------------------------------|
 */

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
        AutoMapperContainer.RegisterServices(services, configuration, typeof(IApplicationService).Assembly);
        DatabaseContainer.RegisterServices(services, configuration);
        RepositoriesContainer.RegisterServices(services, typeof(IDataRepository).Assembly);
        DomainServiceContainer.RegisterServices(services, typeof(IDomainService<,>).Assembly);
        MediatorContainer.RegisterServices(services, configuration, typeof(IApplicationService).Assembly);
        ApplicationServiceContainer.RegisterServices(services, typeof(IApplicationService).Assembly);
        LoggerContainer.RegisterServices(services);
    }
}
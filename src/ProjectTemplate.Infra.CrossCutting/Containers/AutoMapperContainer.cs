using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Mappers.Clientes;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class AutoMapperContainer
{
    internal static void RegisterMappings(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ClienteMapper));
    }
}
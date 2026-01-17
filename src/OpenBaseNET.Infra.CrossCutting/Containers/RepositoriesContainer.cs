/*
 * Name: RepositoriesContainer
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Execução do registro dos repositórios de dados na injeção de dependência
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do RepositoriesContainer            |
 * |--------------------------------------------------------------|
 */

using Microsoft.Extensions.DependencyInjection;
using OpenBaseNET.Infra.Data.Core.Extension;
using System.Reflection;

namespace OpenBaseNET.Infra.CrossCutting.Containers;

internal static class RepositoriesContainer
{
    internal static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        services.AddRepositories(assembly, "OpenBaseNET.Domain.Interfaces.Repositories");
    }
}
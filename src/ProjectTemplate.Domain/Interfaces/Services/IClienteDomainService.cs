using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Domain.Interfaces.Services
{
    public interface IClienteDomainService
    {
        Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNome(string Name);
        Task<IEnumerable<Cliente>?> BuscarClientesPorNomeEF(string Name);
    }
}
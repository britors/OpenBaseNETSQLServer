using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Interfaces.Repositories;

public interface IClienteRepository : IRepositoryBase<Cliente>
{
    Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNomeAsync(string Nome);
}
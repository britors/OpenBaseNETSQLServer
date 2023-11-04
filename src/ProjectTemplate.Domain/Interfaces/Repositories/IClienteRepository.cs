using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Domain.Interfaces.Repositories;

public interface IClienteRepository : IRepositoryBase<Cliente>
{
    Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNomeComDapperAsync(string Nome);
}
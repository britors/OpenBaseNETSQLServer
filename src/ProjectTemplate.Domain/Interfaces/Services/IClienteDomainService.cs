using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Domain.Interfaces.Services;

public interface IClienteDomainService : IDomainService<Cliente, int>
{
    Task<IEnumerable<ClienteQueryResult>?>
        BuscarClientesPorNomeAsync(string Nome);

    Task<PaginationQueryResult<Cliente>>
        BuscarTodosOsClientesPaginandoAsync(int page, int pageSize);
}
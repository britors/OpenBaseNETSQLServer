using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Interfaces.Services;

public interface IClienteDomainService : IDomainService<Cliente, int>
{
    Task<IEnumerable<ClienteQueryResult>?>
        BuscarClientesPorNomeAsync(string Nome);

    Task<PaginationQueryResult<Cliente>>
        BuscarTodosOsClientesPaginandoAsync(int page, int pageSize);
}
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.Interfaces.Services;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Domain.Services;

public sealed class ClienteDomainService : DomainService<Cliente, int>, IClienteDomainService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteDomainService(IClienteRepository clienteRepository) : base(clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<IEnumerable<ClienteQueryResult>?>
        BuscarClientesPorNomeAsync(string Nome)
    {
        return await _clienteRepository.BuscarClientesPorNomeAsync(Nome);
    }

    public async Task<PaginationQueryResult<Cliente>>
        BuscarTodosOsClientesPaginandoAsync(int page, int pageSize)
    {
        var total = await _clienteRepository.CountAsync();
        var result =
            await _clienteRepository.FindAsync(
                pagination: true,
                pageNumber: page,
                pageSize: pageSize);

        return new PaginationQueryResult<Cliente>(page, pageSize, total, result);
    }
}
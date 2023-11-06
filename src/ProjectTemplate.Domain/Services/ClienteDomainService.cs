using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Domain.Services
{
    public sealed class ClienteDomainService : DomainService<Cliente, int>, IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNomeAsync(string Nome)
            => await _clienteRepository.BuscarClientesPorNomeAsync(Nome);

        public async
            Task<PaginationQueryResult<Cliente>> BuscarTodosOsClientesPaginandoAsync(int page, int pageSize)
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
}
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Domain.Services
{
    public class ClienteDomainService : IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNome(string Name)
            => await _clienteRepository.GetByNameAsync(Name);

        public async Task<IEnumerable<Cliente>?> BuscarClientesPorNomeEF(string Name)
            => await _clienteRepository.GetClienteNameEFAsync(Name);
    }
}
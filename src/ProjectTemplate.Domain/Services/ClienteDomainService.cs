﻿using ProjectTemplate.Domain.Entities;
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

        public async Task<IEnumerable<ClienteQueryResult>?> BuscarClientesPorNomeComDapperAsync(string Nome)
            => await _clienteRepository.BuscarClientesPorNomeComDapperAsync(Nome);
    }
}
﻿using ProjectTemplate.Application.DTOs.Cliente.Requests;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
using ProjectTemplate.Application.Interfaces.Extension;

namespace ProjectTemplate.Application.Interfaces.Services;

public interface IClienteApplicationService : IApplicationService
{
    Task<IEnumerable<BuscaClienteResponse>> BuscarClientesPorNomeComDapperAsync(BuscaClientePorNomeRequest request);

    Task<IEnumerable<BuscaClienteResponse>> BuscarClientesPorNomeAsync(BuscaClientePorNomeRequest request);

    Task<AtualizarClienteResponse?> AtualizarAsync(AtualizarClienteRequest request);

    Task<CadastrarClienteResponse?> CadastrarAsync(CadastrarClienteRequest request);

    Task<DeletarClienteResponse?> DeletarAsync(DeletarClienteRequest request);

    Task<BuscaClienteResponse> BuscarClienteAsync(BuscaClienteRequest request);
}
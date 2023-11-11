﻿using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Cliente.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.Clientes.BuscarTodosOsClientes;

internal sealed class BuscarTodosOsClientesQueryHandler :
    IRequestHandler<BuscarTodosOsClientesQuery, PaginatedResponse<BuscaClienteResponse>>
{
    private readonly IClienteDomainService _clienteDomainService;
    private readonly IMapper _mapper;

    public BuscarTodosOsClientesQueryHandler(
        IClienteDomainService clienteDomainService,
        IMapper mapper)
    {
        _clienteDomainService = clienteDomainService;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<BuscaClienteResponse>>
        Handle(BuscarTodosOsClientesQuery request, CancellationToken cancellationToken)
    {
        var queryResult =
            await _clienteDomainService.BuscarTodosOsClientesPaginandoAsync(
                request.Page,
                request.PageSize);
        return _mapper.Map<PaginatedResponse<BuscaClienteResponse>>(queryResult);
    }
}
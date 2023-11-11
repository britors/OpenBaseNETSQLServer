﻿using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Cliente.Responses;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.Clientes.AtualizarCliente;

internal sealed class AtualizarClienteCommandHandler :
    IRequestHandler<AtualizarClienteCommand, AtualizarClienteResponse?>
{
    private readonly IClienteDomainService _clienteDomainService;
    private readonly IMapper _mapper;

    public AtualizarClienteCommandHandler(
        IClienteDomainService clienteDomainService,
        IMapper mapper)
    {
        _clienteDomainService = clienteDomainService;
        _mapper = mapper;
    }

    public async Task<AtualizarClienteResponse?>
        Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = _mapper.Map<Cliente>(request);
        var clienteAtualizado = await _clienteDomainService.UpdateAsync(cliente);
        return _mapper.Map<AtualizarClienteResponse>(clienteAtualizado);
    }
}
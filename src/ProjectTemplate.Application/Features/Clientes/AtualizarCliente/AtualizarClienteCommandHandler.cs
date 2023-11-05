using AutoMapper;
using MediatR;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Services;

namespace ProjectTemplate.Application.Features.Clientes.AtualizarCliente;

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
        var obj = await _clienteDomainService.UpdateAsync(cliente);
        return _mapper.Map<AtualizarClienteResponse>(obj);
    }
}
using AutoMapper;
using MediatR;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Services;

namespace ProjectTemplate.Application.Features.Clientes.DeletarCliente;

internal sealed class DeletarClienteCommandHandler :
    IRequestHandler<DeletarClienteCommand, DeletarClienteResponse?>
{
    private readonly IClienteDomainService _clienteDomainService;
    private readonly IMapper _mapper;

    public DeletarClienteCommandHandler(
        IClienteDomainService clienteDomainService,
        IMapper mapper)
    {
        _clienteDomainService = clienteDomainService;
        _mapper = mapper;
    }

    public async Task<DeletarClienteResponse?>
        Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
    {
        var success = await _clienteDomainService.RemoveByIdAsync(request.Id);
        return new DeletarClienteResponse(success);
    }
}
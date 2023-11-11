using MediatR;
using OpenBaseNET.Application.DTOs.Cliente.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.Clientes.DeletarCliente;

internal sealed class DeletarClienteCommandHandler :
    IRequestHandler<DeletarClienteCommand, DeletarClienteResponse?>
{
    private readonly IClienteDomainService _clienteDomainService;

    public DeletarClienteCommandHandler(IClienteDomainService clienteDomainService)
    {
        _clienteDomainService = clienteDomainService;
    }

    public async Task<DeletarClienteResponse?>
        Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
    {
        var success = await _clienteDomainService.RemoveByIdAsync(request.Id);
        return new DeletarClienteResponse(success);
    }
}
using MediatR;
using OpenBaseNET.Application.DTOs.Cliente.Responses;

namespace OpenBaseNET.Application.Features.Clientes.DeletarCliente;

public sealed class DeletarClienteCommand : IRequest<DeletarClienteResponse?>
{
    public int Id { get; set; }
}
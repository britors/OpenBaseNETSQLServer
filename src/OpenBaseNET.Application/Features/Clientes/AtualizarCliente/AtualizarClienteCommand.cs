using MediatR;
using OpenBaseNET.Application.DTOs.Cliente.Responses;

namespace OpenBaseNET.Application.Features.Clientes.AtualizarCliente;

public sealed class AtualizarClienteCommand : IRequest<AtualizarClienteResponse?>
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}
using MediatR;
using ProjectTemplate.Application.DTOs.Cliente.Responses;

namespace ProjectTemplate.Application.Features.Clientes.AtualizarCliente;

public sealed class AtualizarClienteCommand : IRequest<AtualizarClienteResponse?>
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}
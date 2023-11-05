using MediatR;
using ProjectTemplate.Application.DTOs.Cliente.Responses;

namespace ProjectTemplate.Application.Features.Clientes.DeletarCliente;

public sealed class DeletarClienteCommand : IRequest<DeletarClienteResponse?>
{
    public int Id { get; set; }
}
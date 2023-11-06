using MediatR;
using ProjectTemplate.Application.DTOs.Cliente.Responses;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientePorId;

public sealed class BuscarClientePorIdQuery : IRequest<BuscaClienteResponse>
{
    public int Id { get; set; }
}
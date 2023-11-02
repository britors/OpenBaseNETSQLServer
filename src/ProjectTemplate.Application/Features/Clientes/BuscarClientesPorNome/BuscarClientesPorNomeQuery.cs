using MediatR;
using ProjectTemplate.Application.DTOs.Cliente;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;

internal sealed class BuscarClientesPorNomeQuery : IRequest<IEnumerable<BuscaClienteResponse>>
{
    public required string Nome { get; set; }
}
using MediatR;
using OpenBaseNET.Application.DTOs.Cliente.Responses;

namespace OpenBaseNET.Application.Features.Clientes.BuscarClientesPorNome;

public sealed class BuscarClientesPorNomeQuery : IRequest<IEnumerable<BuscaClienteResponse>>
{
    public string Nome { get; set; } = string.Empty;
}
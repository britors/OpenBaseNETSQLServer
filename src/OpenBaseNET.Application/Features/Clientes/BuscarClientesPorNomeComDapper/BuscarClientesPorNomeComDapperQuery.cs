using MediatR;
using OpenBaseNET.Application.DTOs.Cliente.Responses;

namespace OpenBaseNET.Application.Features.Clientes.BuscarClientesPorNomeComDapper;

public sealed class BuscarClientesPorNomeComDapperQuery : IRequest<IEnumerable<BuscaClienteResponse>>
{
    public string Nome { get; set; } = string.Empty;
}
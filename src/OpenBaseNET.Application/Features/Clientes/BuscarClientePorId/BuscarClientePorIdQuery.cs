using MediatR;
using OpenBaseNET.Application.DTOs.Cliente.Responses;

namespace OpenBaseNET.Application.Features.Clientes.BuscarClientePorId;

public sealed class BuscarClientePorIdQuery : IRequest<BuscaClienteResponse>
{
    public int Id { get; set; }
}
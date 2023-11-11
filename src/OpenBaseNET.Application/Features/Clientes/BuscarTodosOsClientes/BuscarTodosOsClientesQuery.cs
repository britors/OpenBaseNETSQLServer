using MediatR;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Cliente.Responses;

namespace OpenBaseNET.Application.Features.Clientes.BuscarTodosOsClientes;

public sealed class BuscarTodosOsClientesQuery : IRequest<PaginatedResponse<BuscaClienteResponse>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
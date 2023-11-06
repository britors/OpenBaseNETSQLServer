using MediatR;
using ProjectTemplate.Application.DTOs.Base.Response;
using ProjectTemplate.Application.DTOs.Cliente.Responses;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;

public sealed class BuscarTodosOsClientesQuery : IRequest<PaginatedResponse<BuscaClienteResponse>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
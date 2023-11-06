using AutoMapper;
using MediatR;
using ProjectTemplate.Application.DTOs.Base.Response;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Services;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;

internal sealed class BuscarTodosOsClientesQueryHandler :
    IRequestHandler<BuscarTodosOsClientesQuery, PaginatedResponse<BuscaClienteResponse>>
{
    private readonly IClienteDomainService _clienteDomainService;
    private readonly IMapper _mapper;

    public BuscarTodosOsClientesQueryHandler(
        IClienteDomainService clienteDomainService,
        IMapper mapper)
    {
        _clienteDomainService = clienteDomainService;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<BuscaClienteResponse>>
        Handle(BuscarTodosOsClientesQuery request, CancellationToken cancellationToken)
    {
        var total = await _clienteDomainService.CountAsync();
        var result =
            await _clienteDomainService.FindAsync(
                pagination: true,
                pageNumber: request.Page,
                pageSize: request.PageSize);

        var queryResult = new PaginationQueryResult<Cliente>(request.Page, request.PageSize, total, result);
        var response = _mapper.Map<PaginatedResponse<BuscaClienteResponse>>(queryResult);
        return response;
    }
}
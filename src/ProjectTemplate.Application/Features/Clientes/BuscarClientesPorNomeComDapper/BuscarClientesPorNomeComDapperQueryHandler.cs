using AutoMapper;
using MediatR;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
using ProjectTemplate.Domain.Interfaces.Services;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNomeComDapper;

internal sealed class BuscarClientesPorNomeComDapperQueryHandler :
    IRequestHandler<BuscarClientesPorNomeComDapperQuery, IEnumerable<BuscaClienteResponse>>
{
    private readonly IClienteDomainService _clienteDomainService;
    private readonly IMapper _mapper;

    public BuscarClientesPorNomeComDapperQueryHandler(
        IClienteDomainService clienteDomainService,
        IMapper mapper)
    {
        _clienteDomainService = clienteDomainService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BuscaClienteResponse>>
        Handle(BuscarClientesPorNomeComDapperQuery request, CancellationToken cancellationToken)
    {
        var result = await _clienteDomainService.BuscarClientesPorNomeAsync(request.Nome);
        var clientes = _mapper.Map<IEnumerable<BuscaClienteResponse>>(result);
        return clientes;
    }
}
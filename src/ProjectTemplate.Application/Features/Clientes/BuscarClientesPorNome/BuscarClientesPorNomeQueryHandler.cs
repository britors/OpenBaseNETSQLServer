using AutoMapper;
using MediatR;
using ProjectTemplate.Application.DTOs.Cliente;
using ProjectTemplate.Domain.Interfaces.Services;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;

internal sealed class BuscarClientesPorNomeQueryHandler :
    IRequestHandler<BuscarClientesPorNomeQuery, IEnumerable<BuscaClienteResponse>>
{
    private readonly IClienteDomainService _clienteDomainService;
    private readonly IMapper _mapper;

    public BuscarClientesPorNomeQueryHandler(
        IClienteDomainService clienteDomainService,
        IMapper mapper)
    {
        _clienteDomainService = clienteDomainService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BuscaClienteResponse>>
        Handle(BuscarClientesPorNomeQuery request, CancellationToken cancellationToken)
    {
        var result = await _clienteDomainService.BuscarClientesPorNomeAsync(request.Nome);
        var clientes = _mapper.Map<IEnumerable<BuscaClienteResponse>>(result);
        return clientes;
    }
}
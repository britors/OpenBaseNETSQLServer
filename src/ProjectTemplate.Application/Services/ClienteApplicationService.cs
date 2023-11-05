using AutoMapper;
using MediatR;
using ProjectTemplate.Application.DTOs.Cliente;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNomeComDapper;
using ProjectTemplate.Application.Interfaces.Services;

namespace ProjectTemplate.Application.Services;

public sealed class ClienteApplicationService : IClienteApplicationService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ClienteApplicationService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BuscaClienteResponse>>
        BuscarClientesPorNomeComDapperAsync(BuscaClienteRequest request)
    {
        var query = _mapper.Map<BuscarClientesPorNomeComDapperQuery>(request);
        return await _mediator.Send(query);
    }
}
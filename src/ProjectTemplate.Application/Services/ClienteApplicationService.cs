using AutoMapper;
using MediatR;
using ProjectTemplate.Application.DTOs.Cliente.Requests;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
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

    public Task<IEnumerable<BuscaClienteResponse>> BuscarClientesPorNomeAsync(BuscaClienteRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BuscaClienteResponse>>
        BuscarClientesPorNomeComDapperAsync(BuscaClienteRequest request)
    {
        var query = _mapper.Map<BuscarClientesPorNomeComDapperQuery>(request);
        return await _mediator.Send(query);
    }
}
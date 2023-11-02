using AutoMapper;
using MediatR;
using ProjectTemplate.Application.DTOs.Cliente;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;
using ProjectTemplate.Application.Interfaces.Services;

namespace ProjectTemplate.Application.Services;

public class ClienteApplicationService : IClienteApplicationService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ClienteApplicationService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BuscaClienteResponse>> GetByNameAsync(BuscaClienteRequest request)
    {
        var query = _mapper.Map<BuscarClientesPorNomeQuery>(request);
        return await _mediator.Send(query);
    }
}
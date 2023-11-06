using AutoMapper;
using MediatR;
using ProjectTemplate.Application.DTOs.Base.Response;
using ProjectTemplate.Application.DTOs.Cliente.Requests;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
using ProjectTemplate.Application.Features.Clientes.AtualizarCliente;
using ProjectTemplate.Application.Features.Clientes.BuscarClientePorId;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNomeComDapper;
using ProjectTemplate.Application.Features.Clientes.CadastrarCliente;
using ProjectTemplate.Application.Features.Clientes.DeletarCliente;
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

    public async Task<AtualizarClienteResponse?>
        AtualizarAsync(AtualizarClienteRequest request)
    {
        var query = _mapper.Map<AtualizarClienteCommand>(request);
        return await _mediator.Send(query);
    }

    public async Task<IEnumerable<BuscaClienteResponse>>
        BuscarClientesPorNomeAsync(BuscaClientePorNomeRequest request)
    {
        var query = _mapper.Map<BuscarClientesPorNomeQuery>(request);
        return await _mediator.Send(query);
    }

    public async Task<IEnumerable<BuscaClienteResponse>>
        BuscarClientesPorNomeComDapperAsync(BuscaClientePorNomeRequest request)
    {
        var query = _mapper.Map<BuscarClientesPorNomeComDapperQuery>(request);
        return await _mediator.Send(query);
    }

    public async Task<CadastrarClienteResponse?>
        CadastrarAsync(CadastrarClienteRequest request)
    {
        var query = _mapper.Map<CadastrarClienteCommand>(request);
        return await _mediator.Send(query);
    }

    public async Task<DeletarClienteResponse?> DeletarAsync(DeletarClienteRequest request)
    {
        var query = _mapper.Map<DeletarClienteCommand>(request);
        return await _mediator.Send(query);
    }

    public async Task<BuscaClienteResponse> BuscarClienteAsync(BuscaClienteRequest request)
    {
        var query = _mapper.Map<BuscarClientePorIdQuery>(request);
        return await _mediator.Send(query);
    }

    public async Task<PaginatedResponse<BuscaClienteResponse>> TodosOsClientesAsync(TodosOsClientesRequest request)
    {
        var query = _mapper.Map<BuscarTodosOsClientesQuery>(request);
        return await _mediator.Send(query);
    }
}
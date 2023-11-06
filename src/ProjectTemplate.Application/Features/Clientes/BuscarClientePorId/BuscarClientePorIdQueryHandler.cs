using AutoMapper;
using MediatR;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
using ProjectTemplate.Domain.Interfaces.Services;

namespace ProjectTemplate.Application.Features.Clientes.BuscarClientePorId;

internal sealed class BuscarClientePorIdQueryHandler :
    IRequestHandler<BuscarClientePorIdQuery, BuscaClienteResponse>
{
    private readonly IClienteDomainService _clienteDomainService;
    private readonly IMapper _mapper;

    public BuscarClientePorIdQueryHandler(
        IClienteDomainService clienteDomainService,
        IMapper mapper)
    {
        _clienteDomainService = clienteDomainService;
        _mapper = mapper;
    }

    public async Task<BuscaClienteResponse>
        Handle(BuscarClientePorIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _clienteDomainService
            .GetByIdAsync(request.Id);

        var cliente = _mapper.Map<BuscaClienteResponse>(result);
        return cliente;
    }
}
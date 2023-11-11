using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Cliente.Responses;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Application.Features.Clientes.BuscarClientePorId;

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